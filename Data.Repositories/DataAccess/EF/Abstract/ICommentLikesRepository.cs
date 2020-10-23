using Common.Model.Comment.Dto;
using Common.Model.Notification.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ICommentLikesRepository : IEntityRepositoryBase<CommentLikes>
    {
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

        Task<List<DtoGetLikes>> GetLikeNotifications(int userId);

        //Task<List<DtoGetDislikes>> GetDislikeNotifications(int userId);

        /// <summary>
        /// UserId'si verilen kullanıcının CommentLike Entry'lerini döndürür.
        /// </summary>
        /// <param name="userId">Yorum sahibinin UserId'si</param>
        /// <returns></returns>
        Task<List<DtoLikeOrDislike>> GetCommentLikeEntries(int userId);

        //Task<List<DtoLikeOrDislike>> GetCommentDislikeEntries(int userId);
    }
}
