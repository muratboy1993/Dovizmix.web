using Common.Model.ExceptionLog.Dto;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IExceptionLogService
    {

      Task<int> MySqlException (DtoExceptionLog mysqlexception);

    }
}
