using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Common.Model.OpenCloseMarkets.Dto;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class OpenCloseMarketsRepository : EntityRepositoryBase<OpenCloseMarkets>, IOpenCloseMarketsRepository
    {

        private readonly EFDBContext _context;
        public OpenCloseMarketsRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<DtoOpenCloseMarkets>> GetAllMarkets()
        {
            var query = await (from openclosemarkets in _context.OpenCloseMarkets
                               join countries in _context.Countries on openclosemarkets.CountryId equals countries.Id
                               select new DtoOpenCloseMarkets
                               {
                                   Country = countries.Name,
                                   OpenDateTime = openclosemarkets.OpenDateTime,
                                   CloseDateTime = openclosemarkets.CloseDateTime
                               }).ToListAsync();

            return query;

        }

    }
}
