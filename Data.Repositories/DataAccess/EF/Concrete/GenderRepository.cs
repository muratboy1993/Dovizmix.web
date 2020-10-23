using System.Linq;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class GenderRepository : EntityRepositoryBase<Gender>, IGenderRepository
    {
        private readonly EFDBContext _context;
        public GenderRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        //Tüm Cinsiyetleri getirir
        public async Task<List<string>> GetAllGenders()
        {
            var query = await (from genders in _context.Gender
                               select genders.Genders).ToListAsync();
            return query;
        }
    }
}
