using Common.Model.Block.Dto;
using Data.Entities;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IBlockRepository : IEntityRepositoryBase<Blocks>
    {
        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı blocklayıp blocklamadığını kontrol eder.
        /// </summary>
        /// <param name="user">blocklayanın Id ve blocklananın Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        Task<int> CheckBlock(DtoUserBlock user);

        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı blocklayıp blocklamadığını kontrol eder.(nullable)
        /// </summary>
        /// <param name="user">blocklayanın Id ve blocklananın Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        Task<int> CheckBlockNullable(DtoUserBlockNullable user);
    }
}
