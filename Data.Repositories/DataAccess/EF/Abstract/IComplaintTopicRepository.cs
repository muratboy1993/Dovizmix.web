using Common.Model.ComplaintTopic.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IComplaintTopicRepository : IEntityRepositoryBase<ComplaintTopics>
    {
        Task<string> GetTopic(int topicId);
        List<DtoGetComplaintTopic> GetAllTopics();
    }
}
