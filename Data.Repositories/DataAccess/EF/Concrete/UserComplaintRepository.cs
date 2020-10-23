using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.UserComplaint.Dto;
using System.Collections.Generic;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class UserComplaintRepository : EntityRepositoryBase<UserComplaints>, IUserComplaintRepository
    {
        private readonly EFDBContext _context;
        public UserComplaintRepository(EFDBContext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
        }

        /// <summary>
        /// Kullanıcının başka bir kullanıcıyı şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId">Şikayet eden</param>
        /// <param name="targetUserId">Şikayet edilen</param>
        /// <returns></returns>
        public async Task<int> CheckUserComplaint(int userId, int targetUserId)
        {
            var query = await (from complaint in _context.UserComplaints
                         where complaint.ComplainantUserId == userId && complaint.ComplainedUserId == targetUserId
                         select complaint.Id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<DtoGetUserComplaint>> GetUserComplaint(int userId)
        {
            var query = await (from complaint in _context.UserComplaints
                               join topic in _context.ComplaintTopics on complaint.TopicOfComplaintId equals topic.Id
                               join user in _context.Users on complaint.ComplainedUserId equals user.Id
                               where user.Id == userId
                               select new DtoGetUserComplaint
                               {
                                   Username = user.Username,
                                   Topic = topic.Topic,
                                   Complaint = complaint.ComplaintDescription,
                                   ComplaintDateTime = complaint.ComplaintDateTime
                               }).ToListAsync();
            return query;
        }
    }
}
