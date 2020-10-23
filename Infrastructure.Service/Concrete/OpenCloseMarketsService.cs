using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model.OpenCloseMarkets.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;

namespace Infrastructure.Service.Concrete
{
    public class OpenCloseMarketsService : IOpenCloseMarketsService
    {

        private readonly IOpenCloseMarketsRepository _openCloseMarketsRepository;

        public OpenCloseMarketsService(IOpenCloseMarketsRepository openCloseMarketsRepository)
        {

            _openCloseMarketsRepository = openCloseMarketsRepository;



        }

        public async Task<List<DtoOpenCloseMarkets>> GetAllMarkets()
        {
            
            return await _openCloseMarketsRepository.GetAllMarkets();

        }
    }
}
