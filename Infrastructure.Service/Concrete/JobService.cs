using Common.Model.Job.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {

            _jobRepository = jobRepository;
        }

        public async Task<List<string>> GetAllJobs()
        {
            return await _jobRepository.GetAllJobs();
        }
    }
}
