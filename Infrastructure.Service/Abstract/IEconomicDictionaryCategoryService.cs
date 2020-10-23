using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IEconomicDictionaryCategoryService
    {
        Task<List<string>> GetCategories();
    }
}
