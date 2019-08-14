using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Reggora.Api.Util
{
    public static class Utils
    {
        public static Dictionary<string, dynamic> DictionaryOfJsonFields<T>(T obj)
        {
            var dictionary = new Dictionary<string, dynamic>();

            foreach (var property in obj.GetType().GetProperties())
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is JsonPropertyAttribute jsonProperty)
                    {
                        dictionary.Add(jsonProperty.PropertyName, property.GetValue(obj));
                    }
                }
            }

            return dictionary;
        }
        
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