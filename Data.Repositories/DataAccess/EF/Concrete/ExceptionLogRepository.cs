using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class ExceptionLogRepository : EntityRepositoryBase<ExceptionLog>, IExceptionLogRepository
    {

        private readonly EFDBContext _context;
        public ExceptionLogRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


    }
}
