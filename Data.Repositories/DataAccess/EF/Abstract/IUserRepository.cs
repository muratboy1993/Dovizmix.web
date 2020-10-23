using Common.Model.User.Dto;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IUserRepository : IEntityRepositoryBase<Users>
    {
        /// <summary>
        /// Gelen Username ve Emailin Database'de olup olamdığı kontrol eder.
        /// </summary>
        /// <param name="users">Username ve Email</param>
        /// <returns>UserId</returns>
        Task<int> CheckUsernameEmail(DtoUserRegister users);

        /// <summary>
        /// Aldığı userId'ye göre Onaylama Kodunu ve Onaylama kodunun hangi zamana kadar girilebileceği bilgisini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Onaylama kodunu ve geçerliliğini koruduğu max süreyi döndürür.</returns>
        Task<DtoUserCode> GetActivationCode(int userId);

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
        /// Verilen Id'ye sahip olan kullanıcı adını getirir.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>Username</returns>
        Task<string> GetUsername(int id);

        /// <summary>
        /// Girilen string ile başlayan kullanıcıları listeler.
        /// </summary>
        /// <param name="search">Arancak username.</param>
        /// <returns>Userid, username, avatarpath</returns>
        Task<List<DtoUserSearch>> Search(string search);

        /// <summary>
        /// Kullanıcı adı veya email ile şifreyi kontrol eder.
        /// </summary>
        /// <param name="DtoLogin">UsernameOrEmail ve Password</param>
        /// <returns>UserId ve Username</returns>
        Task<DtoResLogin> Login(DtoReqLogin DtoLogin);

        /// <summary>
        /// Login kaydının varlığını kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Login kaydının Id'si</returns>
        Task<int> CheckLoginEntry(int userId);
        
        /// <summary>
        /// Kullanıcının en son giriş yaptığı tarihi getirir.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<DateTime> GetLoginDateTime(int userid);

        /// <summary>
        /// verilen kullanıcı adına sahip olan userId yi getirir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<int> GetUserId(string username);

        

        /// <summary>
        /// Kullanıcının blockladığı ve onu blocklayan kullanıcıların Id'lerini döndürür.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<int>> GetBlockIdList(int userId);

        /// <summary>
        /// Kullanıcının mailini kontrol eder
        /// </summary>
        /// <param name="email">Sorgu atanın maili</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        Task<int> CheckMail(string email);


        Task<DtoRegisterDateExp> GetExperienceScoreAndRegisterDate(int userId);
        
        /// <summary>
        /// En çok beğenilen kullanıcılar dönülüyor. Top 10 list için.
        /// </summary>
        /// <returns></returns>
        Task<List<DtoGetLikedUserList>> GetUserLikedList();

        /// <summary>
        /// En çok beğenilen kullanıcılar dönülüyor. Top 10 list için.
        /// </summary>
        /// <returns></returns>
        Task<List<DtoGetLikedUserList>> GetUserLikedList(int? userId);

        Task<bool> CheckActivation(int userId);

        Task<bool> IsPhoneNumberConfirmed(int userId);

        int GetStarCount(int userId);

        string GetEmail(int userId);
        
    }
}
