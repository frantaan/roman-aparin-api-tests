using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanAparin.Common.Helpers
{
    public static class StringHelper
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars + chars.ToLower(), length)
              .Select(s => s[random.Next(s.Length)]).ToArray()); ;
        }
    }
}
