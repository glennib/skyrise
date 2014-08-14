using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrise.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToGbString(this double value)
        {
            return value.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
        }

        public static double ToDegrees(this double value)
        {
            return value * 180 / Math.PI;
        }

        public static double ToRadians(this double value)
        {
            return value * Math.PI / 180;
        }
    }
}
