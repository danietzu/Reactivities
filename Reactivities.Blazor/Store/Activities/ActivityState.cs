using Reactivities.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ActivityGroupByDate> ActivitiesByDate
        {
            get
            {
                return Activities.GroupBy(a => String.Format("{0:MM/dd/yy}", a.Date))
                                 .Select(x => new ActivityGroupByDate
                                 {
                                     Date = x.Key,
                                     Activities = x.ToList()
                                 })
                                 .ToList();
            }
        }
    }
}