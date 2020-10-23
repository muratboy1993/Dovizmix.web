using Common.Model.OpenCloseMarkets.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IOpenCloseMarketsService
    {

        Task<List<DtoOpenCloseMarkets>> GetAllMarkets();

    }
}
