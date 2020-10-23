using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Common.Model.Job.Dto;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
   public class JobRepository : EntityRepositoryBase<Job>, IJobRepository
    {

        private readonly EFDBContext _context;
        public JobRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        //Tüm Cinsiyetleri getirir
        public async Task<List<string>> GetAllJobs()
        {
            var query = await (from jobs in _context.Job
                               select jobs.Jobs).ToListAsync();

            return query;
        }
    }
}