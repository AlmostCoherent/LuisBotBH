using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bot_Application1.Tools
{
    public static class NumberFormatter
    {
        public static string AddCommasAndCultureInfo(this string returnString, string currencySymbol)
        {
            if(float.TryParse(returnString += "0", out float i))
            {
                return currencySymbol + float.Parse(returnString).ToString("N", new CultureInfo("en-US"));
            }
            return returnString;
        }
    }
}