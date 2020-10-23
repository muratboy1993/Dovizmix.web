using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utility.Abstract
{
    public interface IPasswordEncrypth
    {
        string GetHashSha256(string text);
    }
}
