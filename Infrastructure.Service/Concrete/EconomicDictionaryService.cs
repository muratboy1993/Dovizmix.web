using AutoMapper;
using Common.Model.EconomicDictionary.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class EconomicDictionaryService : IEconomicDictionaryService
    {
        private readonly IEconomicDictionaryRepository _economicDictionaryRepository;
        private readonly IMapper _mapper;

        public EconomicDictionaryService(IEconomicDictionaryRepository economicDictionaryRepository, IMapper mapper)
        {
            _economicDictionaryRepository = economicDictionaryRepository;
            _mapper = mapper;
        }

        public async Task<List<DtoGetAllEconomicDictionary>> GetAll()
        {
            return await _economicDictionaryRepository.GetAllDic();
        }

        public async Task<DtoGetContent> GetContent(string seourl)
        {
            return await _economicDictionaryRepository.GetContent(seourl);
        } 
    }
}
