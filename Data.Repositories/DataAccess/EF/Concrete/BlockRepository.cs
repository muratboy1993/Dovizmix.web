using Common.Model.Block.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class BlockRepository : EntityRepositoryBase<Blocks>, IBlockRepository
    {
        private readonly EFDBContext _context;
        public BlockRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı blocklayıp blocklamadığını kontrol eder.
        /// </summary>
        /// <param name="user">blocklayanın Id ve blocklananın Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckBlock(DtoUserBlock user)
        {
            var query = await (from block in _context.Blocks
                               where user.BlockerId == block.BlockedByUserId && user.BlockedId == block.BlockedUserId
                               select block.Id
                               ).FirstOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// Bir kullanıcının başka bir kullanıcıyı blocklayıp blocklamadığını kontrol eder.(nullable)
        /// </summary>
        /// <param name="user">blocklayanın Id ve blocklananın Id</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckBlockNullable(DtoUserBlockNullable user)
        {
            var query = await (from block in _context.Blocks
                               where user.BlockerId == block.BlockedByUserId && user.BlockedId == block.BlockedUserId
                               select block.Id
                               ).FirstOrDefaultAsync();

            return query;
        }
    }
}
