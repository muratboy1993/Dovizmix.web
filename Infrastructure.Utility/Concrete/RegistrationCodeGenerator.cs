using Infrastructure.Utility.Abstract;
using System;
using System.Linq;

namespace Infrastructure.Utility.Concrete
{
    public class ActivationCodeGenerator : ICodeGenerator
    {
        private Random random = new Random();

        //Standartda kodun uzunluğu 6 karakter olacak.
        public string Create(sbyte length = 6)
        {
            //Karakter seti
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //public string CreatePwd(sbyte length = 8)
        //{
        //    const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


        //}
    }
}
