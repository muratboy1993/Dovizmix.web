using System.Threading.Tasks;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Common.Model.ComplaintTopic.Dto;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class ComplaintTopicRepository : EntityRepositoryBase<ComplaintTopics>,IComplaintTopicRepository
    {
        private readonly EFDBContext _context;
        public ComplaintTopicRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<string> GetTopic(int topicId)
        {
            var query = await (from topic in _context.ComplaintTopics
                               join complaint in _context.CommentComplaints on topic.Id equals complaint.TopicId
                               where complaint.TopicId == topicId
                               select topic.Topic).FirstOrDefaultAsync();
            return query;
        }

        public List<DtoGetComplaintTopic> GetAllTopics()
        {
            var query = (from topic in _context.ComplaintTopics
                         select new DtoGetComplaintTopic{
                             Id = topic.Id,
                             Topic = topic.Topic
                         }).ToList();
            return query;
        }
    }
}
