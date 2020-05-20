using System.Collections.Generic;

namespace Client.Data
{
    public class ActivityGroupByDate
    {
        public string Date { get; set; }
        public List<Activity> Activities { get; set; }
    }
}