using Common.Model.Formations.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IFormationsRepository : IEntityRepositoryBase<Formations>
    {
        Task<DtoGetFormation> GetFormation(string seourl);
        Task<List<DtoGetList>> GetAllByCategory(string category);
        Task<List<DtoGetAllFormations>> GetAllFormations();
    }
}
