using Common.Model.EconomicDictionary.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IEconomicDictionaryRepository : IEntityRepositoryBase<EconomicDictionary>
    {
        Task<DtoGetContent> GetContent(string seourl);

        Task<List<DtoGetAllEconomicDictionary>> GetAllDic();
    }
}
