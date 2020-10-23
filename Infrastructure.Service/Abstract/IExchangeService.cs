using Data.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IExchangeService
    {
        Task<int> AddExchange(Exchanges exchanges);
    }
}
