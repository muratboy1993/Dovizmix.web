using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IGenderRepository
    {
        //Cinsiyetleri getiren
        Task<List<string>> GetAllGenders();

    }
}
