using System;
using System.Globalization;

namespace Presentation.Utils
{
    public static class Convert
    {
        public static int StringToInt(string text)
        {
            return System.Convert.ToInt32(text, CultureInfo.InvariantCulture);
        }

        public static DateTime StringToDateTime(string text)
        {
            return DateTime.Parse(text, CultureInfo.InvariantCulture);
        }
    }
}
