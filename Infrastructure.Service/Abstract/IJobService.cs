using Common.Model.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
   public interface IJobService
    {

        Task<List<string>> GetAllJobs();

    }
}
