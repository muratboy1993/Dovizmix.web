using Infrastructure.Utility.Abstract;
using System;
using System.Security.Cryptography;
using System.Text;



namespace Infrastructure.Utility.Concrete
{
    public class PasswordEncrypt : IPasswordEncrypth
    {
        public string GetHashSha256(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                SHA256Managed hashstring = new SHA256Managed();
                byte[] hash = hashstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString;
            }

            throw new Exception("Şifre boş geçilemez");


        }
    }
}
