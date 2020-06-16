using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Util
{
    public static class Util
    {
        public static DateTime CombineDateAndTime(DateTime date, DateTime time)
        {
            var dt = new DateTime(date.Year, date.Month, date.Day);
            var tm = TimeSpan.Parse(time.ToString("hh:mm"));

            return dt + tm;
        }

        public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        {
            return from p in obj.GetType().GetProperties()
                   where p.PropertyType == typeof(T)
                   select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
        }
    }
}