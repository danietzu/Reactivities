using Fluxor;

namespace Reactivities.Blazor.Store
{
    public class SetEditModeReducer : Reducer<AppState, SetEditModeAction>
    {
        public override AppState Reduce(AppState state, SetEditModeAction action)
        {
            return new AppState { EditMode = action.EditMode };
        }
    }
}