using Data.Entities;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IBannedUserRepository : IEntityRepositoryBase<BannedUsers>
    {
        Task<int> CheckBan(int userId);

        Task<DateTime> GetBanEndTime(int userId);
    }
}

