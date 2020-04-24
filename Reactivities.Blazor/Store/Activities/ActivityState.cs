using Reactivities.Blazor.Data;
using System.Threading;

namespace Reactivities.Blazor.Store.Activities
{
    public class ActivityState
    {
        public Activity SelectedActivity { get; }

        public ActivityState(Activity selectedActivity)
        {
            SelectedActivity = selectedActivity;
        }
    }
}