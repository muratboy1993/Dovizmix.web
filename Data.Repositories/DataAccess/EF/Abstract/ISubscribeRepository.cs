using Common.Model.Subscription.Dto;
using Data.Entities;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ISubscribeRepository : IEntityRepositoryBase<Subscriptions>
    {
        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı takip edip etmediği kontrol eder.
        /// </summary>
        /// <param name="user">Takip edenin Id ve takip edilein Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        Task<int> CheckSubscribe(DtoUserSubscription user);
    }
}
