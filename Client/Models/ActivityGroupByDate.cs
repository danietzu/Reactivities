using System.Collections.Generic;

namespace Client.Models
{
    public class ActivityGroupByDate
    {
        public string Date { get; set; }
        public List<Activity> Activities { get; set; }
    }
}