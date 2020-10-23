using Common.Model.Country.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ICountryRepository
    {

        Task<List<DtoCalendarCountry>> GetAll();

    }
}
