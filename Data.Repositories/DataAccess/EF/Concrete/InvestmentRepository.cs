using Common.Model.Investment.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class InvestmentRepository : EntityRepositoryBase<Investments>, IInvestmentRepository
    {
        private readonly EFDBContext _context;
        public InvestmentRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        //TODO: Geçici çözüm üretildi. Pivot table kullanılarak yapılacak.
        public async Task<List<DtoGetGroupInvestment>> GetAllInvestment(int userId)
        {
            var userMarkets = await (from investment in _context.Investments
                                     join market in _context.Markets on investment.MarketId equals market.Id
                                     where investment.UserId == userId
                                     group market by market.Name into g
                                     select g.Key).ToListAsync();


            List<DtoGetGroupInvestment> list = new List<DtoGetGroupInvestment>();
            foreach (var item in userMarkets)
            {
                var query = await (from inves in _context.Investments
                                   join market in _context.Markets on inves.MarketId equals market.Id
                                   where item == market.Name
                                   select new DtoGetGroupInvestment
                                   {
                                       MarketName = market.Name,
                                       Investments = (from investment in _context.Investments
                                                     join mark in _context.Markets on investment.MarketId equals market.Id
                                                     where userId == investment.UserId && mark.Name == item
                                                     select new DtoGetAllInvestment
                                                     {
                                                         Id = investment.Id,
                                                         MarketName = mark.Name,
                                                         Amount = investment.Amount,
                                                         Price = investment.Price,
                                                         PurchaseDateTime = investment.PurchaseDateTime,
                                                         Note = investment.Note
                                                     }).ToList()
                                   }).FirstOrDefaultAsync();

                list.Add(query);
            }
            return list;
        }

        public async Task<DtoGetAllInvestment> GetInvestment(int investmentId)
        {
            var query = await (from investment in _context.Investments
                               join market in _context.Markets on investment.MarketId equals market.Id
                               where investment.Id == investmentId
                               select new DtoGetAllInvestment
                               {
                                   Id = investment.Id,
                                   MarketName = market.Name,
                                   MarketId = investment.MarketId,
                                   Amount = investment.Amount,
                                   Price = investment.Price,
                                   PurchaseDateTime = investment.PurchaseDateTime,
                                   Note = investment.Note
                               }).FirstOrDefaultAsync();
            return query;
        }
    }
}
