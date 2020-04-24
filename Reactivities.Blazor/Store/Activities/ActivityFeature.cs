using Fluxor;

namespace Reactivities.Blazor.Store.Activities
{
    public class ActivityFeature : Feature<ActivityState>
    {
        public override string GetName() => "Activity";

        protected override ActivityState GetInitialState() => new ActivityState(null);
    }
}