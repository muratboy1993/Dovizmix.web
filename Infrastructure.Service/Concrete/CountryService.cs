using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model.Country.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
namespace Infrastructure.Service.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<DtoCalendarCountry>> GetAll()
        {
            return await _countryRepository.GetAll();
        }
    }
}
