using Common.Model.EconomicDictionary.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IEconomicDictionaryService
    {
        Task<DtoGetContent> GetContent(string seourl);

        Task<List<DtoGetAllEconomicDictionary>> GetAll();
    }
}
