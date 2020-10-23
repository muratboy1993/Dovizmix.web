using Common.Model.City.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ICityRepository
    {

        Task<List<string>> GetAllCities();

    }
}
