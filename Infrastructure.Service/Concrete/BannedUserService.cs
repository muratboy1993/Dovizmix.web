using AutoMapper;
using Common.Model.BannedUser.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class BannedUserService : IBannedUserService
    {
        private readonly IBannedUserRepository _bannedUserRepository;
        private readonly IMapper _mapper;

        public BannedUserService(IBannedUserRepository bannedUserRepository, IMapper mapper)
        {
            _bannedUserRepository = bannedUserRepository;
            _mapper = mapper;
        }

        public async Task<int> CheckBan(int userId)
        {
            return await _bannedUserRepository.CheckBan(userId);
        }

        public async Task<int> BanUser(DtoBannedUser user)
        {
            return await _bannedUserRepository.Add(new BannedUsers
            {
                UserId = user.UserId,
                BanStartDateTime = DateTime.Now,
                BanEndDateTime = user.BanEndTime,
                BanReason = user.Reason
            });


        }

        public async Task<DateTime> GetBanEndTime(int userId)
        {
            return await _bannedUserRepository.GetBanEndTime(userId);
        }
    }
}
