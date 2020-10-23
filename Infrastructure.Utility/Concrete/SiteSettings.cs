using Infrastructure.Utility.Abstract;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utility.Concrete
{
    public class SiteSettings : ISiteSettings
    {
        private readonly IConfiguration _config;

        public SiteSettings(IConfiguration config)
        {
            _config = config; 
        }

        public string GetSiteMessageSettings(string scope, string subScope)
        {
            return _config.GetValue<string>("SiteSettings:" + scope + ":" + subScope);
        }
    }
}
