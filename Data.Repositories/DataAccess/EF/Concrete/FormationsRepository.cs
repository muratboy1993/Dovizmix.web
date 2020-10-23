using Common.Model.Formations.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class FormationsRepository : EntityRepositoryBase<Formations>, IFormationsRepository
    {
        private readonly EFDBContext _context;
        public FormationsRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<DtoGetList>> GetAllByCategory(string category)
        {
            var query = await (from formation in _context.Formations
                               join cate in _context.EconomicDictionaryCategories on formation.CategoryId equals cate.Id
                               where category == cate.Category
                               select new DtoGetList
                               {
                                   Name = formation.Name,
                                   Seourl = formation.Seourl
                               }).ToListAsync();
            return query;
        }

        public async Task<List<DtoGetAllFormations>> GetAllFormations()
        {
            var query = await (from formation in _context.Formations
                               join cate in _context.EconomicDictionaryCategories on formation.CategoryId equals cate.Id
                               select new DtoGetAllFormations
                               {
                                   Category = cate.Category,
                                   Name = formation.Name,
                                   Seourl = formation.Seourl
                               }).ToListAsync();
            return query;
        }

        public async Task<DtoGetFormation> GetFormation(string seourl)
        {
            var query = await (from formation in _context.Formations
                               join cate in _context.EconomicDictionaryCategories on formation.CategoryId equals cate.Id
                               where seourl == formation.Seourl
                               select new DtoGetFormation
                               {
                                   Name = formation.Name,
                                   Content = formation.Content,
                                   Graphic = formation.Graphic,
                                   Category = cate.Category
                               }).FirstOrDefaultAsync();
            return query;
        }
    }



}
