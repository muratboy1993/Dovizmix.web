using Data.Entities;
using Data.Repositories.DataAccess.EF.Concrete;
using Infrastructure.Service.Abstract;
using System.Threading.Tasks;
namespace Infrastructure.Service.Concrete
{
    public class ExchangeService : IExchangeService
    {
        private readonly ExchangeRepository _exchangeRepository;

        public ExchangeService(ExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public async Task<int> AddExchange(Exchanges exchanges)
        {
            return await _exchangeRepository.Add(exchanges);
        }
    }
}
