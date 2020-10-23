using Common.Model.City.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface ICityService
    {

        Task<List<string>> GetAllCities();

    }
}
