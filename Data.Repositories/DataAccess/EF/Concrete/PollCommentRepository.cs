using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class PollCommentRepository : EntityRepositoryBase<CommentPolls>, IPollCommentRepository
    {
        private readonly EFDBContext _context;

        public PollCommentRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
