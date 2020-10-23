using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class EconomicDictionaryCategoryService : IEconomicDictionaryCategoryService
    {
        private readonly IEconomicDictionaryCategoryRepository _economicDictionaryCategoryRepository;

        public EconomicDictionaryCategoryService(IEconomicDictionaryCategoryRepository economicDictionaryCategoryRepository)
        {
            _economicDictionaryCategoryRepository = economicDictionaryCategoryRepository;
        }

        public async Task<List<string>> GetCategories()
        {
            return await _economicDictionaryCategoryRepository.GetCategories();
        }
    }
}
