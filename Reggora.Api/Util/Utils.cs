using System;

namespace Reggora.Api.Util
{
    public static class Utils
    {
        public static string DateToString(DateTime? date)
        {
            if (date == null)
            {
                return "";
            }

            return ((DateTime) (object) date).ToString("yyyy-MM-dd");
        }
        
        public static int? IntFromString(string integer)
        {
            if (integer != null)
            {
                return Int32.Parse(integer);
            }

            return null;
        }
        
        
        public static DateTime? DateTimeFromString(string date)
        {
            if (date != null)
            {
                try
                {
                    return DateTime.Parse(date);
                }
                catch (FormatException)
                {
                }
            }

            return null;
        }
    }
}