using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.Market.Dto;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class MarketRepository : EntityRepositoryBase<Markets>, IMarketRepository
    {
        private readonly EFDBContext _context;

        public MarketRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<DtoGetMarkets>> GetAllMarkets()
        {
            var query = await (from market in _context.Markets
                               select new DtoGetMarkets
                               {
                                   MarketId = market.Id,
                                   MarketName = market.Name
                               }).ToListAsync();
            return query;
        }

        public List<DtoMarketsForCurrencyConverter> GetAllMarketsForCurrencyConverter()
        {
            //Parantez içindeki sorgu tamam
            var subQuery = from exchanges in _context.Exchanges
                           join market in _context.Markets on exchanges.MarketId equals market.Id
                           where market.TypeId == 1
                           group exchanges by exchanges.MarketId into grp
                           select new
                           {
                               MarketId = grp.Key,
                               CreateDate = grp.Max(x => x.CreatedDateTime)
                           };

            //Ana sorgu
            var query = (from market in _context.Markets
                         join exchanges in _context.Exchanges on market.Id equals exchanges.MarketId
                         join subquery in subQuery on market.Id equals subquery.MarketId 
                         join subqueries in subQuery on exchanges.CreatedDateTime equals subqueries.CreateDate
                         select new DtoMarketsForCurrencyConverter
                         {
                             Id = market.Id,
                             Name = market.Name,
                             Code = market.Code,
                             Icon = market.Icon,
                             Unit = market.Unit,
                             LastBuyPrice = exchanges.LastBuyPrice,
                             LastSellPrice = exchanges.LastSellPrice
                         }).ToList();
            return query;
        }

        public async Task<string> GetMarketName(int id)
        {
            var query = await (from market in _context.Markets
                               select market.Name).FirstOrDefaultAsync();
            return query;
        }
    }
}