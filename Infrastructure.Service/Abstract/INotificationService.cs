using Common.Model.Comment.Dto;
using Common.Model.Notification.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface INotificationService
    {
        /// <summary>
        /// Beğenilme bildirimlerini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<DtoGetLikes>> GetLikes(int userId);

        //Task<List<DtoGetDislikes>> GetDislikes(int userId);

        /// <summary>
        /// Bildirimler görüldü olarak güncellenir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> UpdateIsShown(List<DtoLikeOrDislike> likeOrDislike);

        Task<List<int>> GetCommentId(int userId);

        Task<DtoGetBaseComment> GetBaseComment(int notiId);

        Task<int> AddCommentNotification(int userId, int commentId);

        Task<DtoGetEntry> GetEntry(int id);

        Task<int> UpdateIsShown(DtoGetEntry entry);

        Task<int> UpdateIsDelete(DtoGetEntry entry);

        //Task<int> UpdateAllIsDelete(DtoGetEntry entry);

        Task<int> GetNewNotificationCount(int userId);

        //IsShownu false olanlar
        Task<List<int>> GetNotificationIds(int userId);

        Task<List<int>> GetNotificationsIds(int userId);

        Task<int> GetNotificationIdByComment(int commentId, int userId);
    }
}
