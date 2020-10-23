using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model.User.Dto;
using Data.Entities;
using Data.Provider.EF;
using System.Linq;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class UserRolesRepository : EntityRepositoryBase<UserRoles>, IUserRolesRepository
    {
        private readonly EFDBContext _context;
        public UserRolesRepository(EFDBContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Id'si verilen kullanıcının rol isimlerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<DtoRoleName>> GetRoleNames(int userId)
        {

            var query = await (from ur in _context.UserRoles
                               join user in _context.Users on ur.UserId equals user.Id
                               join role in _context.Roles on ur.RoleId equals role.Id
                               where (ur.UserId == userId)
                               select new DtoRoleName
                               {
                                   Name = role.RoleName
                               }).ToListAsync();
            return query;
        }
    }
}
