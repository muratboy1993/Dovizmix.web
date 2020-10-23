using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utility.Abstract
{
    public interface ISeoUrlGenerator
    {
        string GenerateUrl(string title, bool remapToAscii = false, int maxLength = 80);
    }
}
