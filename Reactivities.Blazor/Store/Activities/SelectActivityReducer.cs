using Fluxor;

namespace Reactivities.Blazor.Store.Activities
{
    public class SelectActivityReducer : Reducer<ActivityState, SelectActivityAction>
    {
        public override ActivityState Reduce(ActivityState state, SelectActivityAction action)
        {
            return new ActivityState(action.SelectedActivity);
        }
    }
}