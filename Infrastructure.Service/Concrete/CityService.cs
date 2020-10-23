using Common.Model.City.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
   public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {

            _cityRepository = cityRepository;
        }

        public async Task<List<string>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }
    }
}
