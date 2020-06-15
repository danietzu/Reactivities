using Client.Models;
using System.ComponentModel;

namespace Client.Stores
{
    public partial class RootStore
    {
        private User _currentUser;

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
    }
}