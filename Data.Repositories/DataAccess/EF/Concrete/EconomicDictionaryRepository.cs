using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Model.EconomicDictionary.Dto;
using System.Collections.Generic;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class EconomicDictionaryRepository : EntityRepositoryBase<EconomicDictionary>, IEconomicDictionaryRepository
    {
        private readonly EFDBContext _context;
        public EconomicDictionaryRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<DtoGetAllEconomicDictionary>> GetAllDic()
        {
            var query = await (from dic in _context.EconomicDictionary
                               join cate in _context.EconomicDictionaryCategories on dic.CategoryId equals cate.Id
                               select new DtoGetAllEconomicDictionary
                               {
                                   Category = cate.Category,
                                   Name = dic.Name,
                                   Seourl = dic.Seourl
                               }).ToListAsync();
            return query;
        }

        public async Task<DtoGetContent> GetContent(string seourl)
        {
            var query = await (from dic in _context.EconomicDictionary
                               join cate in _context.EconomicDictionaryCategories on dic.CategoryId equals cate.Id
                              where dic.Seourl == seourl
                               select new DtoGetContent
                              {
                                  Content = dic.Content,
                                  Category = cate.Category,
                                  Name = dic.Name
                              }).FirstOrDefaultAsync();
            return query;
        }
    }
}
