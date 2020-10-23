using Common.Model.Block.Dto;
using Common.Model.Subscription.Dto;
using Common.Model.User.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// Kullanıcı blocklar.
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        Task<int> Block(DtoUserBlock user);

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı bloklayıp blocklamadığını kontrol eder.
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        Task<int> CheckBlock(DtoUserBlock user);

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı bloklayıp blocklamadığını kontrol eder.(nullable)
        /// </summary>
        /// <param name="user">BlockerId(Blocklayan) ve BlockedId(Blocklanan)</param>
        /// <returns></returns>
        Task<int> CheckBlockNullable(DtoUserBlockNullable user);

        /// <summary>
        /// Verilen Id'ye ait olan bloğu siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Unblock(int id);

        /// <summary>
        /// Kullanıcıyı takip eder.
        /// </summary>
        /// <param name="user">SubscriberId(Takip eden) ve SubscribedId(Takip edilen)</param>
        /// <returns></returns>
        Task<int> Subscribe(DtoUserSubscription user);

        /// <summary>
        /// Kullanıcın başka bir kullanıcıyı takip edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="user">SubscriberId(Takip eden) ve SubscribedId(Takip edilen)</param>
        /// <returns></returns>
        Task<int> CheckSubscribe(DtoUserSubscription user);

        /// <summary>
        /// Verilen Id'ye ait olan takibi siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Unsubscribe(int id);

        /// <summary>
        /// Verilen Id'ye sahip olan kullanıcı adını getirir.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>Username</returns>
        Task<string> GetUsername(int id);

        /// <summary>
        /// Takipçileri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takipçilerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanıcıyı takip edenlerin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        Task<List<DtoGetSubscribeUser>> GetSubscribers(int id);

        /// <summary>
        /// Takip edilenleri ve bilgilerini getirir.
        /// </summary>
        /// <param name="id">Takip ettiklerine ulaşılmak istenen kullanıcının Id'si</param>
        /// <returns>Girilen Id'ye sahip kullanının takip ettiklerinin id, kullanıcı adı, seviye, fotoğraf, şehir ve takipçi sayılarını döndürür.</returns>
        Task<List<DtoGetSubscribeUser>> GetSubscribeds(int id);

        /// <summary>
        /// Gelen Username ve Emailin Database'de olup olamdığı kontrol eder.
        /// </summary>
        /// <param name="users">Username ve Email</param>
        /// <returns>UserId</returns>
        Task<int> CheckUsernameEmail(DtoUserRegister user);

        /// <summary>
        /// Login Kaydı ekler.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> AddLoginEntry(int userId);

        /// <summary>
        /// Kullanıcının login entitysini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoUserLogins> GetLoginEntity(int userId);

        /// <summary>
        /// Giriş zamanını ve ip adresini günceller.
        /// </summary>
        /// <param name="loginDate"></param>
        /// <returns></returns>
        Task<int> UpdateLoginDate(DtoUserLogins loginDate);

        /// <summary>
        /// Login kaydının varlığını kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Login kaydının Id'si</returns>
        Task<int> CheckLoginEntry(int userId);

        /// <summary>
        /// Kullanıcının çıkış zamanını günceller.
        /// </summary>
        /// <param name="logoutDate"></param>
        /// <returns></returns>
        Task<int> UpdateLogoutDate(DtoUserLogins logoutDate);

        /// <summary>
        /// Girilen string ile başlayan kullanıcıları listeler.
        /// </summary>
        /// <param name="search">Arancak username.</param>
        /// <returns>Userid, username, avatarpath</returns>
        Task<List<DtoUserSearch>> Search(string searh);

        /// <summary>
        /// Tüm kullanıcıları ve verilerini getirir.
        /// </summary>
        /// <returns></returns>
        Task<List<DtoGetUser>> GetAll();

        /// <summary>
        /// Kullanıcının dondurulma bilgilerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoFrozenUser> GetFrozeEntry(int userId);

        /// <summary>
        /// Kullanıcının dondurulmasını sağlar.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="reason">Sebep</param>
        /// <returns></returns>
        Task<int> Froze(int userId, string reason);

        /// <summary>
        /// Hesabın doldurulmuş durumunu iptal eder.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> Unfroze(DtoFrozenUser user);

        /// <summary>
        /// Verilen Id'ye sahip olan kullanıcının profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoGetUserProfile> GetProfileEntry(int userId);

        /// <summary>
        /// Aktivasyon kodunu günceller.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newCode"></param>
        /// <returns></returns>
        Task<int> UpdateActivationCode(DtoGetUser user, string newCode);

        /// <summary>
        /// Kullanıcı adı veya email ile şifreyi kontrol eder.
        /// </summary>
        /// <param name="DtoLogin">UsernameOrEmail ve Password</param>
        /// <returns>UserId ve Username</returns>
        Task<DtoResLogin> Login(DtoReqLogin DtoLogin);

        /// <summary>
        /// Kullanıcının tecrübe puanını günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        Task<int> UpdateExperienceScore(DtoGetUserProfile profile, sbyte score);

        /// <summary>
        /// Kullanıcının en son giriş yaptığı tarihi getirir.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<DateTime> GetLoginDateTime(int userId);

        /// <summary>
        /// Kullanıcının kayıt kodunu ve süresinin doluş tarihini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoUserCode> GetActivationCode(int userId);

        /// <summary>
        /// Kullanıcıyı aktif yapar.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> ActivateUser(DtoGetUser user);

        /// <summary>
        /// Verilen Id'ye sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoGetUser> GetUser(int userId);

        /// <summary>
        /// Yeni bir kullanıcı oluşturur.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> AddUser(DtoAddUser user);

        /// <summary>
        /// Yeni bir kullanıcı profili oluşturur.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> AddUserProfile(int userId);
        
        /// <summary>
        /// Son görüntülenen sayfayı ve zamanını günceller.
        /// </summary>
        /// <param name="userprofile"></param>
        /// <param name="LastPage"></param>
        /// <returns></returns>
        Task<int> UpdateLastViewedPage(DtoGetUserProfile userprofile, string LastPage);

        /// <summary>
        /// verilen kullanıcı adına sahip olan userId yi getirir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<int> GetId(string username);

        /// <summary>
        /// Id'si verilen kullanıcının rol isimlerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<DtoRoleName>> GetRoleNames(int userId);

        /// <summary>
        /// Kullanıcının mailini kontrol eder
        /// </summary>
        /// <param name="email">Sorgu atanın maili</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        Task<int> CheckMail(string email);

        /// <summary>
        /// Şifre güncelleme işlemini gerçekleştirir.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwdHash"></param>
        /// <returns></returns>
        Task<int> UpdatePassword(DtoGetUser user, string pwdHash);

        /// <summary>
        /// Email'e göre kullanıcı bilgilerini döndürür.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<DtoGetUser> GetUserByEmail(string email);
        
        /// <summary>
        /// Profili günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> UpdateProfile(DtoGetUserProfile profile, DtoUpdateUserProfile user);

        /// <summary>
        /// Avatarın yolunu günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="avatarPath"></param>
        /// <returns></returns>
        Task<int> UpdateAvatarPath(DtoGetUserProfile profile, string avatarPath);

        /// <summary>
        /// Kişisel görüşü günceller.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="opinion"></param>
        /// <returns></returns>
        Task<int> UpdatePersonalOpinion(DtoGetUserProfile profile, string opinion);

        /// <summary>
        /// Kullanıcının blockladığı ve onu blocklayan kullanıcıların Id'lerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<int>> GetBlockIdList(int userId);

        /// <summary>
        /// Görüntülenen kullanıcı profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoUserProfile> GetProfile(int userId);

        /// <summary>
        /// Kullanıcının profil ayarlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoProfileSetting> GetProfileSettings(int userId);

        Task<int> SetLevel(DtoGetUserProfile profile, byte newLevel);

        Task<DtoRegisterDateExp> GetExperienceScoreAndRegisterDate(int userId);

        Task<int> UpdateLevel(DtoGetUserProfile profile, byte newLvl);
        
        Task<List<DtoGetLikedUserList>> GetUserLikedList();

        Task<List<DtoGetLikedUserList>> GetUserLikedList(int? userId);

        Task<bool> CheckActivation(int userId);

        Task<bool> IsPhoneNumberConfirmed(int userId);

        string GetAvatar(int userId);

        Task<DateTime> GetFrozenDate(int userId);

        DtoNameAndSurname GetNameAndSurname(int userId);

        string GetEmail(int userId);

        int GetStarCount(int userId);


    }
}
