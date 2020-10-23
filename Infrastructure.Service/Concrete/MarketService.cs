using AutoMapper;
using Common.Model.Market.Dto;
using Common.Model.Market.Response;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IMapper _mapper;

        public MarketService(IMarketRepository marketRepository, IMapper mapper)
        {
            _marketRepository = marketRepository;
            _mapper = mapper;
        }

        public async Task<List<DtoGetMarkets>> GetAllMarkets()
        {
            return await _marketRepository.GetAllMarkets();
        }

        public async Task<int> GetMarketId(string seourl)
        {
            //todo: gerçek çözüm bul
            if (seourl!="images")
            {
                Markets markets = await _marketRepository.Get(x => x.SeoUrl == seourl);
                return markets.Id;
            }
            else
            {
                return 0;
            } 

        }
        public async Task<string> GetMarketName(int id)
        {
            return await _marketRepository.GetMarketName(id);
        }

        public async Task<int> AddMarket(Markets market) {

            return await _marketRepository.Add(market);
            
        }

        public async Task<int> IsExistsMarket(string code)
        {

            Markets market = await _marketRepository.Get(x=>x.Code==code);
            if (market!=null)
            {
                return market.Id;
            }
            else
            {
                return -1;
            }
            
        }

        public List<DtoMarketsForCurrencyConverter> GetAllMarketsForCurrencyConverter()
        {
            return _marketRepository.GetAllMarketsForCurrencyConverter();
        }
    }
}
