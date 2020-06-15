using Client.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.Stores
{
    public partial class RootStore
    {
        private List<Activity> _activities;
        private Activity _selectedActivity;

        public List<Activity> Activities
        {
            get => _activities;
            set
            {
                if (value != null)
                {
                    _activities = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Activities)));
                }
            }
        }

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                if (value != null)
                {
                    _selectedActivity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedActivity)));
                }
            }
        }
    }
}