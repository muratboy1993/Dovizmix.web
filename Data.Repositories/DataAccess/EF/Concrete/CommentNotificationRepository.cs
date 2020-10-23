using System.Threading.Tasks;
using Common.Model.Notification.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class CommentNotificationRepository : EntityRepositoryBase<CommentNotifications>, ICommentNotificationRepository
    {
        private readonly EFDBContext _context;
        public CommentNotificationRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<int>> GetCommentId(int userId)
        {
            var query = await (from noti in _context.CommentNotifications
                               where noti.UserId == userId && noti.IsDelete == false
                               select noti.CommentId).ToListAsync();
            return query;
        }

        public async Task<DtoGetBaseComment> GetBaseComment(int notiId)
        {
            var query = await (from noti in _context.CommentNotifications
                               //join user in _context.Users on noti.TargetUserId equals user.Id
                               //join comment in _context.Comments on noti.BaseCommentId equals comment.Id
                               where noti.Id == notiId
                               select new DtoGetBaseComment
                               {
                                   //BaseComment = comment.Message,
                                   //BaseUsername = user.Username,
                                   //BaseCreateDateTime = comment.CreatedDateTime
                               }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<int> GetNewNotificationCount(int userId)
        {
            var query = await (from noti in _context.CommentNotifications
                               where noti.UserId == userId && noti.IsShown == false && noti.IsDelete == false
                               select noti.Id).CountAsync();
            return query;
        }

        public async Task<List<int>> GetNotificationIds(int userId)
        {
            var query = await (from commentnot in _context.CommentNotifications
                         where userId == commentnot.UserId && commentnot.IsShown == false
                         select commentnot.Id).ToListAsync();

            return query;
        }

        public async Task<int> GetNotificationIdByComment(int commentId, int userId)
        {
            var query = await (from commentnot in _context.CommentNotifications
                               where commentId == commentnot.CommentId && commentnot.UserId == userId
                               select commentnot.Id).FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<int>> GetNotificationsIds(int userId)
        {
            var query = await (from commentnot in _context.CommentNotifications
                               where userId == commentnot.UserId
                               select commentnot.Id).ToListAsync();

            return query;
        }
    }
}
