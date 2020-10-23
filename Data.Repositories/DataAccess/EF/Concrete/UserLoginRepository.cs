using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class UserLoginRepository : EntityRepositoryBase<UserLogins>, IUserLoginRepository
    {
        private readonly EFDBContext _context;
        public UserLoginRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


    }
}
