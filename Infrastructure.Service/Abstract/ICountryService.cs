using Common.Model.Country.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
   public interface ICountryService
    {

        Task<List<DtoCalendarCountry>> GetAll();

    }
}
