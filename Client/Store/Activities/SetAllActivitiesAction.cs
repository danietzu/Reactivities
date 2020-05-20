using Client.Data;
using System.Collections.Generic;

namespace Client.Store.Activities
{
    public class SetAllActivitiesAction
    {
        public List<Activity> Activities { get; set; }
    }
}