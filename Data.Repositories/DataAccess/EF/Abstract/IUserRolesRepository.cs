using Common.Model.User.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IUserRolesRepository : IEntityRepositoryBase<UserRoles>
    {
        /// <summary>
        /// Id'si verilen kullanıcının rol isimlerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<DtoRoleName>> GetRoleNames(int userId);
    }
}
