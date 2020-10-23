using AutoMapper;
using Common.Model.ExceptionLog.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class ExceptionLogService : IExceptionLogService
    {

        private readonly IExceptionLogRepository _exceptionLogRepository;
        private readonly IMapper _mapper;


        public ExceptionLogService(IExceptionLogRepository exceptionLogRepository, IMapper mapper)
        {
            _exceptionLogRepository = exceptionLogRepository;
            _mapper = mapper;
        }
        public async Task<int> MySqlException(DtoExceptionLog mysqlexception)
        {
            return await _exceptionLogRepository.Add(new ExceptionLog
            {
                Ip = mysqlexception.Ip,
                Method = mysqlexception.Method,
                Path = mysqlexception.Path,
                Source = mysqlexception.Source,
                Message = mysqlexception.Message,

                DateTime = mysqlexception.DateTime

            });
        }
    }
}