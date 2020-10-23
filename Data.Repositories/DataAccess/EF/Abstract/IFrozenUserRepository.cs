using Data.Entities;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IFrozenUserRepository : IEntityRepositoryBase<FrozenUsers>
    {
        Task<DateTime> GetFrozenDate(int userId);
    }
}
