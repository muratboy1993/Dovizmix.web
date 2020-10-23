using Common.Model.Comment.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface ICommentService
    {
        #region YorumSayılarınıDöndürenMetotlar

        /// <summary>
        /// Tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait tüm yorumların sayısını döndürür.</returns>
        Task<int> GetAllCommentCounts(int marketId);

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait tüm yorumların sayısını döndürür.</returns>
        Task<int> GetAllCommentCounts(int marketId, int? userId);

        /// <summary>
        /// Grafikli anketler hariç, grafik içeren tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait grafik içeren yorumların sayısını döndürür.</returns>
        Task<int> GetGraphicCommentCounts(int marketId);

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını ve grafikli anketleri saymayarak grafik içeren yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait grafik içeren yorumların sayısını döndürür.</returns>
        Task<int> GetGraphicCommentCounts(int marketId, int? userId);

        /// <summary>
        /// Anket içeren tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait anket içeren yorumların sayısını döndürür.</returns>
        Task<int> GetOnlyPollCounts(int marketId);

        /// <summary>
        /// Birbirini bloklayan kullanıcıların anketlerini saymayarak anket içeren yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait anket içeren yorumların sayısını döndürür.</returns>
        Task<int> GetOnlyPollCounts(int marketId, int? userId);

        /// <summary>
        /// Sadece yıldızlı kullanıcılara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait sadece yıldızlı kullanıcıların yorum sayısını döndürür.</returns>
        Task<int> GetOnlyStarredCommentCounts(int marketId);

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak sadece yıldızlı kullanıcılara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait sadece yıldızlı kullanıcıların yorum sayısını döndürür.</returns>
        Task<int> GetOnlyStarredCommentCounts(int marketId, int? userId);

        /// <summary>
        /// Online olan kullanıcının takip ettiği userlara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">MarketId</param>
        /// <returns>Verilen marketId'ye ait sadece takip edilen kullanıcıların yorum sayısını döndürür.</returns>
        Task<int> GetOnlySubscribedUserCommentCounts(int marketId, int? userId);

        /// <summary>
        /// Belirli bir ankete cevap olarak yazılmış tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="commentId">Anketin id'si</param>
        /// <returns>Verilen commentId'ye cevap olarak yazılmış yorumların sayısını döndürür.</returns>
        Task<int> GetPollResponseCounts(int commentId);

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak belirli bir ankete cevap olarak yazılmış tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="commentId">Anketin id'si</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen commentId'ye cevap olarak yazılmış yorumların sayısını döndürür.</returns>
        Task<int> GetPollResponseCounts(int commentId, int? userId);

        #endregion

        #region YorumlarınBeğeniSayılarınınDöndürenMetotlar
        /// <summary>
        /// Gelen CommentId'ye göre yorumun beğeni sayısını döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>int tipte yorumun kaç kere beğenildiğini döndürür.</returns>
        Task<int> CommentLikeCount(int commentId);

        /// <summary>
        /// Gelen CommentId'ye göre yorumun beğenmeme sayısını döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>int tipte yorumun kaç kere beğenilmediğini döndürür.</returns>
        Task<int> CommentDislikeCount(int commentId);
        #endregion

        #region TümYorumlarıGetir

        /// <summary>
        /// Giriş yapmamış misafir kullanıcılar için ilgili currency'deki silinmiş yorumlar hariç tüm yorumları (düz yorum, anket ve grafikli) getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int startPage);

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns> 
        Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int? userId, int startPage);

        #endregion

        #region GrafikİçerenYorumlarıGetir

        /// <summary>
        /// Giriş yapmamış misafir kullanıcılar için ilgili market'teki silinmiş yorumlar hariç sadece grafikli yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int startPage);

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek sadece grafik içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int? userId, int startPage);

        #endregion

        #region AnketleriGetir

        /// <summary>
        /// Giriş yapmamış kullanıcılar için ilgili market'teki silinmiş yorumlar hariç sadece anket içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int startPage);

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek sadece anket içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int? userId, int startPage);

        #endregion

        #region YıldızlıKullanıcılarınYorumlarınıGetir

        /// <summary>
        /// Giriş yapmamış kullanıcılar için ilgili market'teki silinmiş yorumlar hariç yıldızlı kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int startPage);

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek yıldızlı kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int? userId, int startPage);

        #endregion

        #region TakipEttiğimKullanıcılarınYorumları

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek takip ettiğim kullanıcıların kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        Task<List<DtoGetComments>> GetOnlySubscribedUserComments(int rowCount, int marketId, int? userId, int startPage);

        #endregion

        #region AnketVeyaGrafiğeYapılanYorumlar

        /// <summary>
        /// Giriş yapmamış kullanıcılar için commentidye göre o ankete ait yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="commentId">Anketin id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir ankete ait yorum listesini döndürür.</returns>
        Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId);

        /// <summary>
        /// Login olmuş kullanıcılar için birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek commentidye göre o ankete ait yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="commentId">Anketin id'sini belirtir.</param>
        /// <param name="userId">Login olan kullanıcının id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir ankete ait yorum listesini döndürür.</returns>
        Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId, int? userId);

        #endregion

        #region YorumBeğenme

        /// <summary>
        /// Yorum beğenme/beğenmeme var mı yok mu diye kontrol ediyor.
        /// </summary>
        /// <param name="likedByUserId">Beğenen kullanıcının Id'si</param>
        /// <param name="relatedCommentId">Beğenilen/Beğenilmeyen yorumun Id'si</param>
        /// <returns>Varsa Id'si dönülüyor.</returns>
        Task<DtoCheckLiked> CheckLikedComment(int likedByUserId, int relatedCommentId);

        /// <summary>
        /// Gün içerisinde 3 kereden fazla beğenme/beğenmeme mevzusu kontrol ediliyor.
        /// </summary>
        /// <param name="likedByUserId">Beğenen kullanıcının Id'si</param>
        /// <param name="likedUserId">Beğenilen/Beğenilmeyen yorumun sahibinin Id'si</param>
        /// <param name="choice">Ankete verilen oyun türü true/false</param>
        /// <returns>Sayısı dönülüyor.</returns>
        Task<int> CheckLikeLimit(int likedByUserId, int likedUserId, bool choice);

        /// <summary>
        /// Verilen commentId'nin sahibinin UserId'si bulunuyor.
        /// </summary>
        /// <param name="commentId">Id</param>
        /// <returns>Id'si dönülüyor.</returns>
        Task<int> GetUserId(int commentId);

        /// <summary>
        /// Yorum beğenme işlemi gelen modele göre db'ye kaydediliyor.
        /// </summary>
        /// <param name="dto">Gelen model</param>
        /// <returns>Beğeni eklendikten sonra yorumun like ve dislike sayıları dönülüyor.</returns>
        Task<DtoLikeOrDislikeCount> AddLikedComment(DtoLikeOrDislike dto);

        /// <summary>
        /// Yorum beğenme işlemi güncelleniyor.
        /// </summary>
        /// <param name="dto">Gelen model</param>
        /// <param name="likeId">Id</param>
        /// <returns>Beğeni güncellendikten sonra yorumun like ve dislike sayıları dönülüyor.</returns>
        Task<DtoLikeOrDislikeCount> UpdateLikedComment(DtoLikeOrDislike dto, int likeId);


        /// <summary>
        /// UserId'si verilen kullanıcının CommentLike Entry'lerini döndürür.
        /// </summary>
        /// <param name="userId">Yorum sahibinin UserId'si</param>
        /// <returns></returns>
        Task<List<DtoLikeOrDislike>> GetCommentLikeEntry(int userId);

        /// <summary>
        /// UserId'si verilen kullanıcının CommentLike Entry'lerini döndürür.
        /// </summary>
        /// <param name="userId">Yorum sahibinin UserId'si</param>
        /// <returns></returns>
        //Task<List<DtoLikeOrDislike>> GetCommentDislikeEntry(int userId);

        #endregion

        //User Profile sayfasındaki kullanıcının grafik, anket, beğenilen ve tüm yorumlarının sorguları.
        #region TekKullanıcınınYorumlarınıGetir

        #region TümYorumlar

        /// <summary>
        /// User Profil sayfası için profil sahibinin tüm yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetAllUserComments(int userId, int rowCount, int startPage);
        /// <summary>
        /// User Profil sayfası için profil sahibinin tüm yorumlarının saysını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetAllUserCommentCount(int userId);

        #endregion

        #region Grafik

        /// <summary>
        /// User Profil sayfası için profil sahibinin grafik içeren yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="onlineUserId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetUserGraphicComments(int userId, int rowCount, int startPage);
        /// <summary>
        /// User Profil sayfası için profil sahibinin grafik içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetUserGraphicCommentCount(int userId);

        #endregion

        #region Anket

        /// <summary>
        /// User Profil sayfası için profil sahibinin anket içeren yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="onlineUserId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetUserPolls(int userId, int rowCount, int startPage);
        /// <summary>
        /// User Profil sayfası için profil sahibinin anket içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetUserPollCount(int userId);

        #endregion

        #region Beğenilen

        /// <summary>
        /// User Profil sayfası için profil sahibinin beğenilen yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetUserLikedComments(int userId, int rowCount, int startPage);
        /// <summary>
        /// User Profil sayfası için profil sahibinin beğenilen yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetUserLikedCount(int userId);

        #endregion

        #endregion

        /// <summary>
        /// Tek bir anket veya grafik yorumu getirir.
        /// </summary>
        /// <param name="pollId"></param>
        /// <returns></returns>
        Task<DtoGetComments> GetPollOrGraphicComment(int commentId);

        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>DTOGetComments tipinde tek yorum döndürür.</returns>
        Task<DtoGetComments> GetComment(int commentId);

        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>DTOGetComments tipinde tek yorum döndürür.</returns>
        Task<DtoGetComments> GetComment(int commentId, int userId);

        /// <summary>
        /// Verilen commentId'nin sahibinin username'ini bulur.
        /// </summary>
        /// <param name="commentId">CommentParentId</param>
        /// <returns>Username döner.</returns>
        Task<string> GetUsername(int? commentId);

        /// <summary>
        /// Verilen CommentId'nin commentParentId parametresini bulur.
        /// </summary>
        /// <param name="commentId">Yorumun id'si</param>
        /// <returns>CommentId'ye göre CommentParentId'sini döndürür.</returns>
        Task<int?> GetParentId(int commentId);

        /// <summary>
        /// Online kullanıcı ankete oy kullanıp kullanmadığını bulur.
        /// </summary>
        /// <param name="userId">Online olan kullanıcının id'si</param>
        /// <param name="pollId">Anketin id'si</param>
        /// <returns>Kullanıcının hangi seçeneğe oy verdiği yani pollOptionId döner.</returns>
        Task<int> GetUserPollVote(int? userId, int? pollId);

        /// <summary>
        /// İlgili ankete yapılan toplam oy sayısı verir.
        /// </summary>
        /// <param name="pollOptionId">Anketin seçeneğini belirtir.</param>
        /// <returns>Verilen anket seçeneğinin sayısını döndürür.</returns>
        Task<int> TotalVoteCount(int pollOptionId);

        /// <summary>
        /// İlgili anketin anket seçenekleri, seçeneklerin idleri, ve her bir seçeneğin oy sayısını döndürür.
        /// </summary>
        /// <param name="pollId">Anketin Id'si</param>
        /// <returns>DTOPollOptions tipinde anketin seçeneklerini liste şeklinde döndürür.</returns>
        Task<List<DtoPollOptions>> GetPollOptions(int? pollId);
        
        /// <summary>
        /// Gelen modele göre graphic yorumu graphicComments tablosuna ekler.
        /// </summary>
        /// <returns></returns>
        Task<int> AddGraphic(DtoAddGraphicComments model);

        /// <summary>
        /// Gelen modele göre yorum database'e ekleniyor.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Db'ye kaydedilip sonuç int olarak dönülüyor.</returns>
        Task<int> AddComment(DtoAddComments model);

        /// <summary>
        /// Gelen modele göre ankete yapılan seçim db'ye kaydediliyor.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Db'ye kaydedilip sonuç int olarak dönülüyor.</returns>
        Task<int> AddPollVote(DtoAddPollVotes model);

        /// <summary>
        /// Anket ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddPoll(DtoAddPollComment model);

        /// <summary>
        /// Anket seçeneklerini ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddPollOption(DtoAddPollOptions model);

        /// <summary>
        /// Message'ı verilen yorumun id'sini döndürür.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<int> GetCommentId(int pollId);

        /// <summary>
        /// CommentId'si verilen anketin PollId'sini döndürür.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Task<int> GetPollId(int commentId);

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int marketId);

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int userId, int marketId);


        //CommentId'ye göre yorum mesajı getiriliyor.
        Task<string> GetMessage(int commentId);

        //Task<string> GetReponses(int commentId);
    }
}
