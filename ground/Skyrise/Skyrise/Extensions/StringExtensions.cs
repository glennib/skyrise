using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrise.Extensions
{
    public static class StringExtensions
    {
        public static double ToGbDouble(this string value)
        {
            double result;
            double.TryParse(value,System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"), out result);
            return result;
        }
    }
}
