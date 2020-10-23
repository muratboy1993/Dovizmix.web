using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IGenderService
    {

        Task<List<string>> GetAllGenders();

    }
}
