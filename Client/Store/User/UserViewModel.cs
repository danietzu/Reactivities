using Client.Models;
using System.ComponentModel;

namespace Client.Store
{
    public class UserViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                if (value != null && value != _user)
                {
                    _user = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(User)));
                }
            }
        }
    }
}