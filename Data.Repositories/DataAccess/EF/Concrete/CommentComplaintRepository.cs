using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.CommentComplaint.Dto;
using System.Collections.Generic;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class CommentComplaintRepository : EntityRepositoryBase<CommentComplaints>, ICommentComplaintRepository
    {
        private readonly EFDBContext _context;
        public CommentComplaintRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Kullanıcının bir yorumu şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <returns>Bulduğu şikayetin Id'sini döndürür.</returns>
        public async Task<int> CheckCommentComplaint(int userId, int commentId)
        {
            var query = await (from complaint in _context.CommentComplaints
                         where complaint.UserId == userId && complaint.CommentId == commentId
                         select complaint.Id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<DtoGetCommentComplaint>> GetCommentComplaint(int userId)
        {
            var query = await (from complaint in _context.CommentComplaints
                               join topic in _context.ComplaintTopics on complaint.TopicId equals topic.Id
                               join comment in _context.Comments on complaint.CommentId equals comment.Id
                               join user in _context.Users on comment.UserId equals user.Id
                               where complaint.UserId == userId
                               select new DtoGetCommentComplaint
                               {
                                   Username = user.Username,
                                   Comment = comment.Message,
                                   Topic = topic.Topic,
                                   Complaint = complaint.ComplaintDescription,
                                   ComplaintDateTime = complaint.ComplaintDateTime
                               }).ToListAsync();
            return query;
        }

        public async Task<string> GetState(int complaintId)
        {
            var query = await (from complaint in _context.CommentComplaints
                               where complaintId == complaint.Id
                               select complaint.State).FirstOrDefaultAsync();
            return query;
        }
    }
}
