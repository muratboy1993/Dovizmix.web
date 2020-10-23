using Data.Entities;
using Data.Provider.EF;
using System.Threading.Tasks;
using Data.Repositories.DataAccess.EF.Abstract;
using Common.Model.User.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class UserProfileRepository : EntityRepositoryBase<UserProfiles>, IUserProfileRepository
    {
        private readonly EFDBContext _context;
        public UserProfileRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public string GetAvatar(int userId)
        {
            var query = (from up in _context.UserProfiles
                         where up.Id == userId
                         select up.AvatarPath).FirstOrDefault();
            return query;
        }

        public DtoNameAndSurname GetNameAndSurname(int userId)
        {
            var query = (from up in _context.UserProfiles
                         where up.Id == userId
                         select new DtoNameAndSurname
                         {
                             Name = up.Name,
                             Surname = up.Surname
                         }).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// Görüntülenen kullanıcı profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoUserProfile> GetProfile(int userId)
        {
            var query = await (from up in _context.UserProfiles
                               join user in _context.Users on up.UserId equals user.Id
                               where up.UserId == userId
                               select new DtoUserProfile
                               {
                                   Id = up.Id,
                                   AvatarPath = up.AvatarPath,
                                   City = up.City,
                                   DateOfBirth = up.DateOfBirth,
                                   ExperienceScore = up.ExperienceScore,
                                   FacebookProfile = up.FacebookProfile,
                                   InstagramProfile = up.InstagramProfile,
                                   TwitterProfile = up.TwitterProfile,
                                   Gender = up.Gender,
                                   Job = up.Job,
                                   LastPageViewed = up.LastPageViewed,
                                   LastPageViewedDateTime = up.LastPageViewedDateTime,
                                   PersonalOpinion = up.PersonalOpinion,
                                   UserLevel = up.UserLevel,
                                   RegisterDate = user.RegistrationDateTime,
                                   Username = user.Username,
                                   SubscriberCount = (from subscription in _context.Subscriptions
                                                      where subscription.SubscribedUserId == user.Id
                                                      select subscription.SubscribedUserId).Count(),
                                   SubscribedCount = (from subscription in _context.Subscriptions
                                                      where subscription.SubscribedByUserId == user.Id
                                                      select subscription.SubscribedByUserId).Count(),
                                   CommentCount = (from comment in _context.Comments
                                                   where comment.UserId == userId
                                                   select comment.Id).Count(),
                                   Name = up.Name,
                                   Surname = up.Surname
                               }).FirstOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Kullanıcının profil ayarlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoProfileSetting> GetProfileSettings(int userId)
        {
            var blockedMembers = await (from block in _context.Blocks
                                        join user in _context.Users on block.BlockedUserId equals user.Id
                                        join up in _context.UserProfiles on user.Id equals up.UserId
                                        where block.BlockedByUserId == userId
                                        select new DtoBlockedMember
                                        {
                                            UserId = block.BlockedUserId,
                                            Username = user.Username
                                        }).ToListAsync();


            var query = await (from up in _context.UserProfiles
                               join user in _context.Users on up.UserId equals user.Id
                               where up.UserId == userId
                               select new DtoProfileSetting
                               {
                                   Id = up.Id,
                                   AvatarPath = up.AvatarPath,
                                   City = up.City,
                                   DateOfBirth = up.DateOfBirth,
                                   FacebookProfile = up.FacebookProfile,
                                   InstagramProfile = up.InstagramProfile,
                                   TwitterProfile = up.TwitterProfile,
                                   Gender = up.Gender,
                                   Job = up.Job,
                                   Name = up.Name,
                                   Surname = up.Surname,
                                   PersonalOpinion = up.PersonalOpinion,
                                   Username = user.Username,
                                   Email = user.Email,
                                   PhoneNumber = up.PhoneNumber,
                                   BlockedMembers = blockedMembers,
                                   Level = up.UserLevel
                               }).FirstOrDefaultAsync();
            return query;
        }
    }
}
