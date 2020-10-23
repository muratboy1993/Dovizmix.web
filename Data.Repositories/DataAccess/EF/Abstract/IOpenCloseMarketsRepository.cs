using Common.Model.OpenCloseMarkets.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IOpenCloseMarketsRepository : IEntityRepositoryBase<OpenCloseMarkets>
    {
        /// <summary>
        /// Açık piyasaları getirir
        /// </summary>
        /// <returns>Tüm açık piyasaları getirir</returns>
        Task<List<DtoOpenCloseMarkets>> GetAllMarkets();

    }
}
