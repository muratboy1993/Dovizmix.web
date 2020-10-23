using AutoMapper;
using Common.Model.Block.Dto;
using Common.Model.Subscription.Dto;
using Common.Model.User.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly ISubscribeRepository _subscribeRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IFrozenUserRepository _frozenUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IUserRolesRepository _userRolesRepository;
        
        public UserService(IUserRepository userRepository, IUserProfileRepository userProfileRepository, IBlockRepository blockRepository, ISubscribeRepository subscribeRepository, IUserLoginRepository userLoginRepository, IHttpContextAccessor httpContextAccessor, IFrozenUserRepository frozenUserRepository, IMapper mapper, IUserRolesRepository userRolesRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
            _blockRepository = blockRepository;
            _subscribeRepository = subscribeRepository;
            _userLoginRepository = userLoginRepository;
            _frozenUserRepository = frozenUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userRolesRepository = userRolesRepository;
        }

        /// <summary>
        /// Kullanıcı blocklar.
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        public async Task<int> Block(DtoUserBlock user)
        {
            return await _blockRepository.Add(new Blocks
            {
                BlockedByUserId = user.BlockerId,
                BlockedUserId = user.BlockedId,
                CreatedDateTime = DateTime.Now
            });
        }

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı bloklayıp blocklamadığını kontrol eder.
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        public async Task<int> CheckBlock(DtoUserBlock user)
        {
            return await _blockRepository.CheckBlock(user);
        }

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı bloklayıp blocklamadığını kontrol eder.(nullable)
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        public async Task<int> CheckBlockNullable(DtoUserBlockNullable user)
        {
            return await _blockRepository.CheckBlockNullable(user);
        }

        /// <summary>
        /// Verilen Id'ye ait olan bloğu siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Unblock(int id)
        {
            return await _blockRepository.Delete(id);
        }

        /// <summary>
        /// Kullanıcıyı takip eder.
        /// </summary>
        /// <param name="user">SubscriberId(Takip eden) ve SubscribedId(Takip edilen)</param>
        /// <returns></returns>
        public async Task<int> Subscribe(DtoUserSubscription user)
        {
            return await _subscribeRepository.Add(new Subscriptions
            {
                SubscribedByUserId = user.SubscriberId,
                SubscribedUserId = user.SubscribedId,
                CreatedDateTime = DateTime.Now
            });
        }

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı takip edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="user">SubscriberId(Takip eden) ve SubscribedId(Takip edilen)</param>
        /// <returns></returns>
        public async Task<int> CheckSubscribe(DtoUserSubscription user)
        {
            return await _subscribeRepository.CheckSubscribe(user);
        }

        /// <summary>
        /// Verilen Id'ye ait olan takibi siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Unsubscribe(int id)
        {
            return await _subscribeRepository.Delete(id);
        }

        /// <summary>
        /// Takipçileri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takipçilerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanıcıyı takip edenlerin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        public async Task<List<DtoGetSubscribeUser>> GetSubscribers(int id)
        {
            return await _userRepository.GetSubscribers(id);
        }

        /// <summary>
        /// Takip edilenleri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takip ettiklerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanının takip ettiklerinin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        public async Task<List<DtoGetSubscribeUser>> GetSubscribeds(int id)
        {
            return await _userRepository.GetSubscribeds(id);
        }

        /// <summary>
        /// Verilen Id'ye sahip olan kullanıcı adını getirir.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>Username</returns>
        public async Task<string> GetUsername(int id)
        {
            return await _userRepository.GetUsername(id);
        }

        /// <summary>
        /// Gelen Username ve Emailin Database'de olup olamdığı kontrol eder.
        /// </summary>
        /// <param name="users">Username ve Email</param>
        /// <returns>UserId</returns>
        public async Task<int> CheckUsernameEmail(DtoUserRegister user)
        {
            return await _userRepository.CheckUsernameEmail(user);
        }

        /// <summary>
        /// Login kaydının varlığını kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Login kaydının Id'si</returns>
        public async Task<int> CheckLoginEntry(int userId)
        {
            return await _userRepository.CheckLoginEntry(userId);
        }

        /// <summary>
        /// Login Kaydı ekler.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> AddLoginEntry(int userId)
        {
            return await _userLoginRepository.Add(new UserLogins
            {
                UserId = userId,
                LastLoginDateTime = DateTime.Now,
                IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
            });
        }

        /// <summary>
        /// Kullanıcının login entitysini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoUserLogins> GetLoginEntity(int userId)
        {
            return await _mapper.Map<Task<DtoUserLogins>>(_userLoginRepository.Get(x => x.UserId == userId));
        }

        /// <summary>
        /// Giriş zamanını ve ip adresini günceller.
        /// </summary>
        /// <param name="loginDate"></param>
        /// <returns></returns>
        public async Task<int> UpdateLoginDate(DtoUserLogins loginDate)
        {
            var map = _mapper.Map<UserLogins>(loginDate);
            map.LastLoginDateTime = DateTime.Now;
            map.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return await _userLoginRepository.Update(map);
        }

        /// <summary>
        /// Kullanıcının çıkış zamanını günceller.
        /// </summary>
        /// <param name="logoutDate"></param>
        /// <returns></returns>
        public async Task<int> UpdateLogoutDate(DtoUserLogins logoutDate)
        {
            var map = _mapper.Map<UserLogins>(logoutDate);
            map.LastLogoutDateTime = DateTime.Now;
            return await _userLoginRepository.Update(map);
        }
        
        /// <summary>
        /// Girilen string ile başlayan kullanıcıları listeler.
        /// </summary>
        /// <param name="search">Arancak username.</param>
        /// <returns>Userid, username, avatarpath</returns>
        public async Task<List<DtoUserSearch>> Search(string search)
        {
            return await _userRepository.Search(search);
        }

        /// <summary>
        /// Tüm kullanıcıları ve verilerini getirir.
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoGetUser>> GetAll()
        {
            return await _mapper.Map<Task<List<DtoGetUser>>>(_userRepository.GetAll());
        }

        /// <summary>
        /// Kullanıcının dondurulma bilgilerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoFrozenUser> GetFrozeEntry(int userId)
        {
            return await _mapper.Map<Task<DtoFrozenUser>>(_frozenUserRepository.Get(x => x.UserId == userId));
        }

        /// <summary>
        /// Kullanıcının dondurulmasını sağlar.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="reason">Sebep</param>
        /// <returns></returns>
        public async Task<int> Froze(int userId, string reason)
        {
            return await _frozenUserRepository.Add(new FrozenUsers
            {
                UserId = userId,
                FrozenReason = reason,
                FrozenDateTime = DateTime.Now
            });
        }

        /// <summary>
        /// Hesabın doldurulmuş durumunu iptal eder.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> Unfroze(DtoFrozenUser user)
        {
            var map = _mapper.Map<FrozenUsers>(user);
            return await _frozenUserRepository.Delete(map);
        }

        /// <summary>
        /// Kullanıcının tecrübe puanını günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public async Task<int> UpdateExperienceScore(DtoGetUserProfile profile, sbyte score)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.ExperienceScore = map.ExperienceScore + score;
            return await _userProfileRepository.Update(map);
        }

        /// <summary>
        /// Verilen Id'ye sahip olan kullanıcının profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoGetUserProfile> GetProfileEntry(int userId)
        {
            return await _mapper.Map<Task<DtoGetUserProfile>>(_userProfileRepository.Get(x => x.UserId == userId));
        }

        /// <summary>
        /// Kullanıcının en son giriş yaptığı tarihi getirir.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<DateTime> GetLoginDateTime(int userId)
        {
            return await _userRepository.GetLoginDateTime(userId);
        }

        /// <summary>
        /// Kullanıcı adı veya email ile şifreyi kontrol eder.
        /// </summary>
        /// <param name="DtoLogin">UsernameOrEmail ve Password</param>
        /// <returns>UserId ve Username</returns>
        public async Task<DtoResLogin> Login(DtoReqLogin DtoLogin)
        {
            return await _userRepository.Login(DtoLogin);
        }

        /// <summary>
        /// Kullanıcının kayıt kodunu ve süresinin doluş tarihini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoUserCode> GetActivationCode(int userId)
        {
            return await _userRepository.GetActivationCode(userId);
        }

        /// <summary>
        /// Kullanıcıyı aktif yapar.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> ActivateUser(DtoGetUser user)
        {
            var map = _mapper.Map<Users>(user);
            map.IsEmailConfirmed = true;
            map.ActivationDateTime = DateTime.Now;
            return await _userRepository.Update(map);
        }

        /// <summary>
        /// Verilen Id'ye sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoGetUser> GetUser(int userId)
        {
            return await _mapper.Map<Task<DtoGetUser>>(_userRepository.GetById(userId));
        }

        /// <summary>
        /// Yeni bir kullanıcı oluşturur.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> AddUser(DtoAddUser user)
        {
            return await _userRepository.Add(new Users
            {
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                ActivationCode = user.Code,
                IsEmailConfirmed = false,
                IsPhoneNumberConfirmed = false,
                RegistrationDateTime = DateTime.Now,
                ActivationCodeExpirationDateTime = DateTime.Now.AddDays(1)
                
            });
        }

        /// <summary>
        /// Yeni bir kullanıcı profili oluşturur.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> AddUserProfile(int userId)
        {
            return await _userProfileRepository.Add(new UserProfiles
            {
                UserId = userId,
                DateOfBirth = DateTime.Now
            });
        }

        /// <summary>
        /// Son görüntülenen sayfayı ve zamanını günceller.
        /// </summary>
        /// <param name="userprofile"></param>
        /// <param name="LastPage"></param>
        /// <returns></returns>
        public async Task<int> UpdateLastViewedPage(DtoGetUserProfile userprofile, string LastPage)
        {
            var map = _mapper.Map<UserProfiles>(userprofile);
            map.LastPageViewed = LastPage;
            map.LastPageViewedDateTime = DateTime.Now;
            return await _userProfileRepository.Update(map);
        }

        /// <summary>
        /// verilen kullanıcı adına sahip olan userId yi getirir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<int> GetId(string username)
        {
            return await _userRepository.GetUserId(username);
        }

        /// <summary>
        /// Kullanıcının mailini kontrol eder
        /// </summary>
        /// <param name="email">Sorgu atanın maili</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckMail(string email)
        {
            return await _mapper.Map<Task<int>>(_userRepository.CheckMail(email));
        }

        /// <summary>
        /// Id'si verilen kullanıcının rol isimlerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<DtoRoleName>> GetRoleNames(int userId)
        {
            return await _userRolesRepository.GetRoleNames(userId);
        }

        /// <summary>
        /// Aktivasyon kodunu günceller.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newCode"></param>
        /// <returns></returns>
        public async Task<int> UpdateActivationCode(DtoGetUser user, string newCode)
        {
            var map = _mapper.Map<Users>(user);
            map.ActivationCode = newCode;
            map.ActivationCodeExpirationDateTime = DateTime.Now.AddDays(1);
            return await _userRepository.Update(map);
        }

        /// <summary>
        /// Şifre güncelleme işlemini gerçekleştirir.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwdHash"></param>
        /// <returns></returns>
        public async Task<int> UpdatePassword(DtoGetUser user, string pwdHash)
        {
            var map = _mapper.Map<Users>(user);
            map.PasswordHash = pwdHash;
            return await _userRepository.Update(map);
        }

        /// <summary>
        /// Email'e göre kullanıcı bilgilerini döndürür.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<DtoGetUser> GetUserByEmail(string email)
        {
            return await _mapper.Map<Task<DtoGetUser>>(_userRepository.Get(x => x.Email == email));
        }
        
        /// <summary>
        /// Profili günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> UpdateProfile(DtoGetUserProfile profile, DtoUpdateUserProfile user)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.Gender = user.Gender;
            map.City = user.City;
            map.DateOfBirth = user.DateOfBirth;
            map.FacebookProfile = user.FacebookProfile;
            map.InstagramProfile = user.InstagramProfile;
            map.Job = user.Job;
            map.Name = user.Name;
            map.Surname = user.Surname;
            map.TwitterProfile = user.TwitterProfile;
            return await _userProfileRepository.Update(map);
        }

        /// <summary>
        /// Avatarın yolunu günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="avatarPath"></param>
        /// <returns></returns>
        public async Task<int> UpdateAvatarPath(DtoGetUserProfile profile, string avatarPath)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.AvatarPath = avatarPath;
            return await _userProfileRepository.Update(map);
        }

        /// <summary>
        /// Kişisel görüşü günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="opinion"></param>
        /// <returns></returns>
        public async Task<int> UpdatePersonalOpinion(DtoGetUserProfile profile, string opinion)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.PersonalOpinion = opinion;
            return await _userProfileRepository.Update(map);
        }

        /// <summary>
        /// Kullanıcının blockladığı ve onu blocklayan kullanıcıların Id'lerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<int>> GetBlockIdList(int userId)
        {
            return await _userRepository.GetBlockIdList(userId);
        }

        /// <summary>
        /// Görüntülenen kullanıcı profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoUserProfile> GetProfile(int userId)
        {
            return await _userProfileRepository.GetProfile(userId);
        }

        /// <summary>
        /// Kullanıcının profil ayarlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoProfileSetting> GetProfileSettings(int userId)
        {
            return await _userProfileRepository.GetProfileSettings(userId);
        }

        public async Task<int> SetLevel(DtoGetUserProfile profile, byte newLevel)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.UserLevel = newLevel;
            return await _userProfileRepository.Update(map);
        }

        public async Task<DtoRegisterDateExp> GetExperienceScoreAndRegisterDate(int userId)
        {
            return await _userRepository.GetExperienceScoreAndRegisterDate(userId);
        }

        public async Task<int> UpdateLevel(DtoGetUserProfile profile , byte newLvl)
        {
            var map = _mapper.Map<UserProfiles>(profile);
            map.UserLevel = newLvl;
            return await _userProfileRepository.Update(map);
        }
        
        public async Task<List<DtoGetLikedUserList>> GetUserLikedList()
        {
            return await _userRepository.GetUserLikedList();
        }

        public async Task<List<DtoGetLikedUserList>> GetUserLikedList(int? userId)
        {
            return await _userRepository.GetUserLikedList(userId);
        }

        public async Task<bool> CheckActivation(int userId)
        {
            return await _userRepository.CheckActivation(userId);
        }

        public async Task<bool> IsPhoneNumberConfirmed(int userId)
        {
            return await _userRepository.IsPhoneNumberConfirmed(userId);
        }

        public string GetAvatar(int userId)
        {
            return _userProfileRepository.GetAvatar(userId);
        }

        public DtoNameAndSurname GetNameAndSurname(int userId)
        {
            return _userProfileRepository.GetNameAndSurname(userId);
        }

        public string GetEmail(int userId)
        {
            return _userRepository.GetEmail(userId);
        }

        public int GetStarCount(int userId)
        {
            return _userRepository.GetStarCount(userId);
        }

        public async Task<DateTime> GetFrozenDate(int userId)
        {
            return await _frozenUserRepository.GetFrozenDate(userId);
        }
    }
}
