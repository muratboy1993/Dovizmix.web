using Common.Model.Notification.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ICommentNotificationRepository : IEntityRepositoryBase<CommentNotifications>
    {
        Task<List<int>> GetCommentId(int userId);

        Task<DtoGetBaseComment> GetBaseComment(int notiId);

        Task<int> GetNewNotificationCount(int userId);

        //IsShownu false olanlar
        Task<List<int>> GetNotificationIds(int userId);

        Task<List<int>> GetNotificationsIds(int userId);

        Task<int> GetNotificationIdByComment(int commentId, int userId);
    }
}
