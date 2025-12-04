using MMNGS.DataAccess.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestWpf.Models;

namespace TestWpf.ViewModels
{
    public class HeaderViewModel : INotifyPropertyChanged
    {
        private string _title;
        private AdminModel _adminProfile;

        public HeaderViewModel()
        {
            _title = "Admin";
            _adminProfile = new AdminModel(); // Initialize to avoid null reference
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public AdminModel AdminProfile
        {
            get => _adminProfile;
            set
            {
                if (_adminProfile != value)
                {
                    _adminProfile = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
