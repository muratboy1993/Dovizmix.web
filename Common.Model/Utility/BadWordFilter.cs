using System;
using System.Text.RegularExpressions;

namespace Common.Model.Utility
{
    public static class BadWordFilter
    {
        public static string BadWord(string message)
        {
            if (message != null)
            {
                //var buildDir = Environment.CurrentDirectory;
                //var path = buildDir + @"\wwwroot\files\badwords.txt";
                var path = @"D:\VS\DovizApp\UI.Mvc\wwwroot\files\badwords.txt";
                string[] badWords = FileReader.ReadLines(path);

                foreach (var item in badWords)
                {
                    var pattern = @"\b" + item + @"\b";
                    if (Regex.IsMatch(message, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                    {
                        message = Regex.Replace(message, pattern, "", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                    }
                }
            }
            return message;
        }
    }
}
