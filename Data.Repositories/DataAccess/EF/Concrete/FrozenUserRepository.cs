using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class FrozenUserRepository : EntityRepositoryBase<FrozenUsers>, IFrozenUserRepository
    {
        private readonly EFDBContext _context;
        public FrozenUserRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<DateTime> GetFrozenDate(int userId)
        {
            var query = await (from frozen in _context.FrozenUsers
                               where userId == frozen.UserId
                               select frozen.FrozenDateTime).FirstOrDefaultAsync();
            return query;
        }
    }
}
