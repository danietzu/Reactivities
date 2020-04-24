using Fluxor;

namespace Reactivities.Blazor.Store
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";

        protected override AppState GetInitialState() => new AppState
        {
            EditMode = false
        };
    }
}