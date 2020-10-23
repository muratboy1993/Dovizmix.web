using Common.Model.UserRoles.Dto;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IUserRolesService
    {
        Task<int> AddRole(DtoAddUserRoles model);
    }
}
