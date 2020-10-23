using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utility.Abstract
{
    public interface ISiteSettings
    {
        string GetSiteMessageSettings(string scope, string subScope);
    }
}
