using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class BannedUserRepository : EntityRepositoryBase<BannedUsers>, IBannedUserRepository
    {
        private readonly EFDBContext _context;
        public BannedUserRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        /// <summary>
        /// Bir kullanıcının banlı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="userId">banlananın ID si</param>
        /// <returns>Bulunan kayıtın Id'si döndürürlür.Bulunamaz ise 0 döner.</returns>
        public async Task<int> CheckBan(int userId)
        {
            var query = await (from ban in _context.BannedUsers
                               where userId == ban.UserId && DateTime.Now < ban.BanEndDateTime
                               select ban.Id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<DateTime> GetBanEndTime(int userId)
        {
            var query = await (from ban in _context.BannedUsers
                               where userId == ban.UserId
                               select ban.BanEndDateTime).FirstOrDefaultAsync();
            return query;
        }
    }
}
