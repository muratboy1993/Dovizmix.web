using System.Threading.Tasks;
using Data.Entities;
using System.Linq;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class PollVotesRepository : EntityRepositoryBase<CommentPollVotes>, IPollVotesRepository
    {
        private readonly EFDBContext _context;
        public PollVotesRepository(EFDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
