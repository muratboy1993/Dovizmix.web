using Common.Model.Formations.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IFormationsService
    {
        Task<DtoGetFormation> GetFormation(string seourl);
        Task<List<DtoGetList>> GetAllByCategory(string category);
        Task<List<DtoGetAllFormations>> GetAllFormations();
    }
}
