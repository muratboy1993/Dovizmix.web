using Common.Model.Market.Dto;
using Common.Model.Market.Response;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IMarketService
    {

        Task<int> GetMarketId(string seourl);

        Task<List<DtoGetMarkets>> GetAllMarkets();
        List<DtoMarketsForCurrencyConverter> GetAllMarketsForCurrencyConverter();
        Task<string> GetMarketName(int id);
        Task<int> IsExistsMarket(string code);
        Task<int> AddMarket(Markets markets);

    }
}
