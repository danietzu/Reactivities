using Reactivities.Blazor.Data;
using System.Collections.Generic;

namespace Reactivities.Blazor.Store.Activities
{
    public class ActivityState
    {
        public List<Activity> Activities { get; }
        public Activity SelectedActivity { get; }

        public ActivityState(List<Activity> activities, Activity selectedActivity)
        {
            Activities = activities;
            SelectedActivity = selectedActivity;
        }
    }
}