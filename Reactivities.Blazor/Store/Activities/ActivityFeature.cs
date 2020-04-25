using Fluxor;
using Reactivities.Blazor.Data;
using System.Collections.Generic;

namespace Reactivities.Blazor.Store.Activities
{
    public class ActivityFeature : Feature<ActivityState>
    {
        public override string GetName() => "Activity";

        protected override ActivityState GetInitialState() => new ActivityState(new List<Activity>(), null);
    }
}