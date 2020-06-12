using Client.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.Storage
{
    public class StorageService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _currentUser;
        private List<Activity> _activities;
        private Activity _selectedActivity;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value != null && value != _currentUser)
                {
                    _currentUser = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentUser)));
                }
            }
        }

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