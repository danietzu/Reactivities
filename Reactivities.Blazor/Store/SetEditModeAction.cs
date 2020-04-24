namespace Reactivities.Blazor.Store
{
    public class SetEditModeAction
    {
        public bool EditMode { get; set; }

        public SetEditModeAction(bool editMode)
        {
            EditMode = editMode;
        }
    }
}