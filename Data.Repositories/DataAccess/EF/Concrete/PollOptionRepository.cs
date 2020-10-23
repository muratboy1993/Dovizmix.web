using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class PollOptionRepository : EntityRepositoryBase<CommentPollOptions>, IPollOptionRepository
    {
        private readonly EFDBContext _context;

        public PollOptionRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
