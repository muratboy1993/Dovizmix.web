using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class EconomicDictionaryCategoryRepository : EntityRepositoryBase<AlphabeticCategories>,IEconomicDictionaryCategoryRepository
    {
        private readonly EFDBContext _context;
        public EconomicDictionaryCategoryRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<string>> GetCategories()
        {
            var query = await (from dic in _context.EconomicDictionaryCategories
                               select dic.Category).ToListAsync();
            return query;
        }
    }
}
