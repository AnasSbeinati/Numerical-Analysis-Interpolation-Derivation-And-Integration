using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ta7lilProject
{
    public static class Share
    {
        public static bool PositiveInteger(this string s)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(s);
        }
        public static bool Isnumber(this string s)
        {
            Regex regex = new Regex(@"^-?[0-9]{0,7}(\.[0-9]{1,6})?$|^-?(10000)(\.[0]{1,2})?$");
            return regex.IsMatch(s);
        }
        public static bool IfallZero(double[] x)
        {
            return x.All(element => element == 0);
        }


    }
}
