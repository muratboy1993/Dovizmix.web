using Common.Model.Market.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IMarketRepository : IEntityRepositoryBase<Markets>
    {
        Task<List<DtoGetMarkets>> GetAllMarkets();

        Task<string> GetMarketName(int id);

        List<DtoMarketsForCurrencyConverter> GetAllMarketsForCurrencyConverter();

    }
}
