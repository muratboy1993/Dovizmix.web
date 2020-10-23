using Common.Model.User.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class UserRepository : EntityRepositoryBase<Users>, IUserRepository
    {
        private readonly EFDBContext _context;
        public UserRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Gelen Username ve Emailin Database'de olup olamdığı kontrol eder.
        /// </summary>
        /// <param name="users">Username ve Email</param>
        /// <returns>UserId</returns>
        public async Task<int> CheckUsernameEmail(DtoUserRegister users)
        {
            var query = await (from user in _context.Users
                               where (user.Username == users.Username || user.Email == users.Email)
                               select user.Id).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Aldığı userId'ye göre Onaylama Kodunu ve Onaylama kodunun hangi zamana kadar girilebileceği bilgisini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Onaylama kodunu ve geçerliliğini koruduğu max süreyi döndürür.</returns>
        public async Task<DtoUserCode> GetActivationCode(int userId)
        {
            var query = await (from user in _context.Users
                               where (user.Id == userId)
                               select new DtoUserCode
                               {
                                   ActivationCode = user.ActivationCode,
                                   ActivationCodeExpirationDateTime = user.ActivationCodeExpirationDateTime
                               }).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Takipçileri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takipçilerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanıcıyı takip edenlerin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        public async Task<List<DtoGetSubscribeUser>> GetSubscribers(int id)
        {
            var query = await (from user in _context.Users
                               join subscribe in _context.Subscriptions on user.Id equals subscribe.SubscribedByUserId
                               join userProfile in _context.UserProfiles on subscribe.SubscribedByUserId equals userProfile.UserId
                               where (id == subscribe.SubscribedUserId)
                               select new DtoGetSubscribeUser
                               {
                                   UserId = user.Id,
                                   City = userProfile.City,
                                   ImagePath = userProfile.AvatarPath,
                                   UserLevel = userProfile.UserLevel,
                                   Username = user.Username,
                                   SubscriberCount = (from subscription in _context.Subscriptions
                                                      where subscription.SubscribedUserId == user.Id
                                                      select subscription.SubscribedUserId
                                                      ).Count()
                               }).ToListAsync();
            return query;
        }

        /// <summary>
        /// Takip edilenleri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takip ettiklerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanının takip ettiklerinin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        public async Task<List<DtoGetSubscribeUser>> GetSubscribeds(int id)
        {
            var query = await (from user in _context.Users
                               join subscribe in _context.Subscriptions on user.Id equals subscribe.SubscribedUserId
                               join userProfile in _context.UserProfiles on subscribe.SubscribedUserId equals userProfile.UserId
                               where (id == subscribe.SubscribedByUserId)
                               select new DtoGetSubscribeUser
                               {
                                   UserId = user.Id,
                                   City = userProfile.City,
                                   ImagePath = userProfile.AvatarPath,
                                   UserLevel = userProfile.UserLevel,
                                   Username = user.Username,
                                   SubscriberCount = (from subscription in _context.Subscriptions
                                                      where subscription.SubscribedUserId == user.Id
                                                      select subscription.SubscribedUserId
                                                      ).Count()
                               }).ToListAsync();
            return query;
        }

        /// <summary>
        /// Verilen Id'ye sahip olan kullanıcı adını getirir.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>Username</returns>
        public async Task<string> GetUsername(int id)
        {
            var query = await (from user in _context.Users
                               where user.Id == id
                               select user.Username).SingleOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Girilen string ile başlayan kullanıcıları listeler.
        /// </summary>
        /// <param name="search">Arancak username.</param>
        /// <returns>Userid, username, avatarpath</returns>
        public async Task<List<DtoUserSearch>> Search(string search)
        {
            var query = await (from user in _context.Users
                               join userProfile in _context.UserProfiles on user.Id equals userProfile.Id
                               select new DtoUserSearch
                               {
                                   Id = user.Id,
                                   Username = user.Username,
                                   AvatarPath = userProfile.AvatarPath

                               }).Where(x => x.Username.ToLower().StartsWith(search.ToLower())).ToListAsync();
            return query;
        }

        /// <summary>
        /// Kullanıcı adı veya email ile şifreyi kontrol eder.
        /// </summary>
        /// <param name="DtoLogin">UsernameOrEmail ve Password</param>
        /// <returns>UserId ve Username</returns>
        public async Task<DtoResLogin> Login(DtoReqLogin DtoLogin)
        {

            var query = await (from user in _context.Users
                               join up in _context.UserProfiles on user.Id equals up.UserId
                               where ((user.Username == DtoLogin.UsernameOrEmail || user.Email == DtoLogin.UsernameOrEmail) && user.PasswordHash == DtoLogin.Password)
                               select new DtoResLogin
                               {
                                   Id = user.Id,
                                   Username = user.Username,
                                   Email = user.Email,
                                   IsEmailConfirmed = user.IsEmailConfirmed,
                                   IsPhoneNumberConfirmed = user.IsPhoneNumberConfirmed,
                                   Name = up.Name,
                                   Surname = up.Surname,
                                   AvatarPath = up.AvatarPath,
                                   StarCount = up.UserLevel
                               }).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Login kaydının varlığını kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Login kaydının Id'si</returns>
        public async Task<int> CheckLoginEntry(int userId)
        {
            var query = await (from userLogin in _context.UserLogins
                               where userLogin.UserId == userId
                               select userLogin.Id).FirstOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Kullanıcının en son giriş yaptığı tarihi getirir.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<DateTime> GetLoginDateTime(int userid)
        {
            var query = await (from userLogin in _context.UserLogins
                               where userLogin.UserId == userid
                               select userLogin.LastLoginDateTime).FirstOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Kullanıcının mailini kontrol eder
        /// </summary>
        /// <param name="email">Sorgu atanın maili</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckMail(string email)
        {
            var query = await (from mail in _context.Users
                               where email == mail.Email
                               select mail.Id).SingleOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// verilen kullanıcı adına sahip olan userId yi getirir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<int> GetUserId(string username)
        {
            var query = await (from user in _context.Users
                               where user.Username == username
                               select user.Id).SingleOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Kullanıcının blockladığı ve onu blocklayan kullanıcıların Id'lerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<int>> GetBlockIdList(int userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            return kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar).ToList();
        }

        public async Task<DtoRegisterDateExp> GetExperienceScoreAndRegisterDate(int userId)
        {
            var query = await (from user in _context.Users
                               join profile in _context.UserProfiles on user.Id equals profile.UserId
                               where user.Id == userId
                               select new DtoRegisterDateExp
                               {
                                   ExperienceScore = profile.ExperienceScore,
                                   RegisterDateTime = user.RegistrationDateTime,
                                   IsEmailConfirmed = user.IsEmailConfirmed
                               }).FirstOrDefaultAsync();

            return query;
        }
        
        /// <summary>
        /// En çok beğenilen kullanıcılar dönülüyor. Top 10 list için.
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoGetLikedUserList>> GetUserLikedList()
        {
            var query = await (from user in _context.Users
                               join up in _context.UserProfiles on user.Id equals up.UserId
                               select new DtoGetLikedUserList
                               {
                                   Id = user.Id,
                                   Username = user.Username,
                                   AvatarPath = up.AvatarPath,
                                   UserLevel = up.UserLevel,
                                   TotalLikeCount = (from cl in _context.CommentLikes
                                                     join comment in _context.Comments on cl.CommentId equals comment.Id
                                                     join us in _context.Users on comment.UserId equals us.Id
                                                     where cl.LikedOrDisliked == true && us.Id == user.Id
                                                     select cl.LikedOrDisliked).Count()
                               }).Where(x => x.TotalLikeCount > 0).OrderByDescending(x => x.TotalLikeCount).Take(10).ToListAsync();
            return query;
        }

        public async Task<List<DtoGetLikedUserList>> GetUserLikedList(int? userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blocklist = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar).ToList();
            
            var query = await (from user in _context.Users
                               join up in _context.UserProfiles on user.Id equals up.UserId
                               where !blocklist.Contains(user.Id)
                               select new DtoGetLikedUserList
                               {
                                   Id = user.Id,
                                   Username = user.Username,
                                   AvatarPath = up.AvatarPath,
                                   UserLevel = up.UserLevel,
                                   TotalLikeCount = (from cl in _context.CommentLikes
                                                     join comment in _context.Comments on cl.CommentId equals comment.Id
                                                     join us in _context.Users on comment.UserId equals us.Id
                                                     where cl.LikedOrDisliked == true && us.Id == user.Id
                                                     select cl.LikedOrDisliked).Count()
                               }).Where(x => x.TotalLikeCount > 0).OrderByDescending(x => x.TotalLikeCount).Take(10).ToListAsync();
            return query;
        }

        public async Task<bool> CheckActivation(int userId)
        {
            var query = await (from user in _context.Users
                               where user.Id == userId
                               select user.IsEmailConfirmed).FirstOrDefaultAsync();
            return query;
        }

        public async Task<bool> IsPhoneNumberConfirmed(int userId)
        {
            var query = await (from user in _context.Users
                               where user.Id == userId
                               select user.IsPhoneNumberConfirmed).FirstOrDefaultAsync();
            return query;
        }

        public string GetEmail(int userId)
        {
            var query = (from user in _context.Users
                              where user.Id == userId
                              select user.Email).FirstOrDefault();
            return query;
        }

        public int GetStarCount(int userId)
        {
            var query = (from user in _context.Users
                               join up in _context.UserProfiles on user.Id equals up.UserId
                               where user.Id == userId
                               select up.UserLevel).FirstOrDefault();
            return query;
        }
    }
}