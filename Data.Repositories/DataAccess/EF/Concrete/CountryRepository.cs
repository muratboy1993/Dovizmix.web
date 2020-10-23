using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.Country.Dto;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class CountryRepository : EntityRepositoryBase<Countries>, ICountryRepository
    {
        private readonly EFDBContext _context;
        public CountryRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<DtoCalendarCountry>> GetAll()
        {

            var query = await (from country in _context.Countries
                               select new DtoCalendarCountry
                               {
                                   CountryId = country.Id,

                                   CountryFlagCode = country.FlagCode,

                                   CountryName = country.Name

                               }).ToListAsync();
            return query;

        }
    }
}
