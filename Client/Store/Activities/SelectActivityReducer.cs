using Fluxor;

namespace Client.Store.Activities
{
    public class SelectActivityReducer : Reducer<ActivityState, SelectActivityAction>
    {
        public override ActivityState Reduce(ActivityState state, SelectActivityAction action)
        {
            return new ActivityState(state.Activities, action.SelectedActivity);
        }
    }
}