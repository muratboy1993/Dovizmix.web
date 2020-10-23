using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utility.Abstract
{
    public interface IPasswordGenerator
    {

       bool PasswordIsValid(bool includeLowercase = true, bool includeUppercase = true, bool includeNumeric = true, bool includeSpecial = false, bool includeSpaces = false, string password = "12");

       string GeneratePassword(bool includeLowercase = true, bool includeUppercase = true, bool includeNumeric = true, bool includeSpecial = false, bool includeSpaces = false, int lengthOfPassword=8);

    }
}
