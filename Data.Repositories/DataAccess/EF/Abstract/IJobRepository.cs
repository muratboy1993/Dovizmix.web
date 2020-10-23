using Common.Model.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IJobRepository
    {
        //Meslekleri Getiren
        Task<List<string>> GetAllJobs();
    }
}
