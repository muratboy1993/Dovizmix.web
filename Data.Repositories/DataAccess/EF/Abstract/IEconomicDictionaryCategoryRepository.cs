using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IEconomicDictionaryCategoryRepository : IEntityRepositoryBase<AlphabeticCategories>
    {
        Task<List<string>> GetCategories();
    }
}
