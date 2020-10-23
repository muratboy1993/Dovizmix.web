using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService (IGenderRepository genderRepository)
        {

            _genderRepository = genderRepository;
        }
        public async Task<List<string>> GetAllGenders()
        {

            return await _genderRepository.GetAllGenders();

        }

    }
}
