using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.Subscription.Dto;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class SubscribeRepository : EntityRepositoryBase<Subscriptions>, ISubscribeRepository
    {
        private readonly EFDBContext _context;
        public SubscribeRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı takip edip etmediği kontrol eder.
        /// </summary>
        /// <param name="user">Takip edenin Id ve takip edilein Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckSubscribe(DtoUserSubscription user)
        {
            var query = await (from subs in _context.Subscriptions
                               where user.SubscriberId == subs.SubscribedByUserId && user.SubscribedId == subs.SubscribedUserId
                               select subs.Id
                               ).FirstOrDefaultAsync();

            return query;
        }
    }
}
