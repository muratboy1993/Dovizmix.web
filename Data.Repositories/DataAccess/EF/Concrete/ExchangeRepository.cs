using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class ExchangeRepository : EntityRepositoryBase<Exchanges>, IExchangeRepository
    {
        private readonly EFDBContext _context;

        public ExchangeRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
