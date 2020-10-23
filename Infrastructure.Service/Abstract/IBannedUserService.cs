using Common.Model.BannedUser.Dto;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IBannedUserService
    {
        Task<int> BanUser(DtoBannedUser user);
        Task<int> CheckBan(int userId);

        Task<DateTime> GetBanEndTime(int userId);
    }
}
