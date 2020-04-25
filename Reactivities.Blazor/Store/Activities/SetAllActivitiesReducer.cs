using Fluxor;

namespace Reactivities.Blazor.Store.Activities
{
    public class SetAllActivitiesReducer : Reducer<ActivityState, SetAllActivitiesAction>
    {
        public override ActivityState Reduce(ActivityState state, SetAllActivitiesAction action)
        {
            return new ActivityState(action.Activities, state.SelectedActivity);
        }
    }
}