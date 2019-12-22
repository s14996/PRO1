using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_API.Utils
{
    public static class Common
    {
        public static bool EqualsCaseInsensitive(this string s, string equals)
        {
            return s.Trim().ToUpper().Equals(equals.Trim().ToUpper());
        }
    }
}
