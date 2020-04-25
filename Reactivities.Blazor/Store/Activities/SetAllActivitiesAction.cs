using Reactivities.Blazor.Data;
using System.Collections.Generic;

namespace Reactivities.Blazor.Store.Activities
{
    public class SetAllActivitiesAction
    {
        public List<Activity> Activities { get; set; }
    }
}