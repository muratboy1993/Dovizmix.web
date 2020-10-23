using Common.Model.Investment.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IInvestmentService
    {
        Task<int> AddInvestment(DtoAddInvestment model);

        Task<int> UpdateInvestment(DtoUpdateInvestment model);

        Task<bool> DeleteInvestment(int investmentId);

        Task<List<DtoGetGroupInvestment>> GetAllInvestment(int userId);

        Task<DtoGetAllInvestment> GetInvestment(int investmentId);
    }
}
