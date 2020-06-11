using Fluxor;
using Client.Models;
using System.Collections.Generic;

namespace Client.Store.Activities
{
    public class ActivityFeature : Feature<ActivityState>
    {
        public override string GetName() => "Activity";

        protected override ActivityState GetInitialState() => new ActivityState(new List<Activity>(), null);
    }
}