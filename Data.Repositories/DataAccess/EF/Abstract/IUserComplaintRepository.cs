using Common.Model.UserComplaint.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IUserComplaintRepository : IEntityRepositoryBase<UserComplaints>
    {
        /// <summary>
        /// Kullanıcının başka bir kullanıcıyı şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId">Şikayet eden</param>
        /// <param name="targetUserId">Şikayet edilen</param>
        /// <returns></returns>
        Task<int> CheckUserComplaint(int userId, int targetUserId);

        Task<List<DtoGetUserComplaint>> GetUserComplaint(int userId);
    }
}