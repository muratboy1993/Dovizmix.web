using System.Threading.Tasks;
using Common.Model.UserRoles.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;

namespace Infrastructure.Service.Concrete
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesRepository _userRolesRepository;

        public UserRolesService(IUserRolesRepository userRolesRepository)
        {
            _userRolesRepository = userRolesRepository;
        }

        //Kullanıcıya Rol atama işlemi
        public async Task<int> AddRole(DtoAddUserRoles model)
        {
            return await _userRolesRepository.Add(new Data.Entities.UserRoles
            {
                RoleId = model.RoleId,
                UserId = model.UserId
            });
        }
    }
}
