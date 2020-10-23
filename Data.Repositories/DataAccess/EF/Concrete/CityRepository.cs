using Common.Model.City.Dto;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class CityRepository : EntityRepositoryBase<City>, ICityRepository
    {

        private readonly EFDBContext _context;
        public CityRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        //Tüm Cinsiyetleri getirir
        public async Task<List<string>> GetAllCities()
        {
            var query = await (from cities in _context.City
                               select cities.Cities).ToListAsync();

            return query;

        }
    }
}
