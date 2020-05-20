using System;

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
    }
}