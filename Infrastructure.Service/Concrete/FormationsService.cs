using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model.Formations.Dto;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;

namespace Infrastructure.Service.Concrete
{
    public class FormationsService : IFormationsService
    {
        private readonly IFormationsRepository _formationsRepository;

        public FormationsService(IFormationsRepository formationsRepository)
        {
            _formationsRepository = formationsRepository;
        }

        public async Task<List<DtoGetList>> GetAllByCategory(string category)
        {
            return await _formationsRepository.GetAllByCategory(category);
        }

        public async Task<List<DtoGetAllFormations>> GetAllFormations()
        {
            return await _formationsRepository.GetAllFormations();
        }

        public async Task<DtoGetFormation> GetFormation(string seourl)
        {
            return await _formationsRepository.GetFormation(seourl);        
        }
    }
}
