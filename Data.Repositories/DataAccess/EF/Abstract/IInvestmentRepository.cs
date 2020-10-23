using Common.Model.Investment.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IInvestmentRepository : IEntityRepositoryBase<Investments>
    {
        Task<List<DtoGetGroupInvestment>> GetAllInvestment(int userId);

        Task<DtoGetAllInvestment> GetInvestment(int investmentId);
    }
}
