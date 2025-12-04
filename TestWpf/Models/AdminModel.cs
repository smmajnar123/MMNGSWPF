using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestWpf.Models
{
    public class AdminModel : INotifyPropertyChanged
    {
        private string _name;
        private string _email;
        private string _messName;
        private string _address;
        private string _phoneNumber;
        private int _duration;
        private decimal _price;
        private DateOnly _subscriptionExpiry;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => _name;
            set { if (_name != value) { _name = value; OnPropertyChanged(); } }
        }

        public string Email
        {
            get => _email;
            set { if (_email != value) { _email = value; OnPropertyChanged(); } }
        }

        public string MessName
        {
            get => _messName;
            set { if (_messName != value) { _messName = value; OnPropertyChanged(); } }
        }

        public string Address
        {
            get => _address;
            set { if (_address != value) { _address = value; OnPropertyChanged(); } }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { if (_phoneNumber != value) { _phoneNumber = value; OnPropertyChanged(); } }
        }

        public int Duration
        {
            get => _duration;
            set { if (_duration != value) { _duration = value; OnPropertyChanged(); } }
        }

        public decimal Price
        {
            get => _price;
            set { if (_price != value) { _price = value; OnPropertyChanged(); } }
        }

        public DateOnly SubscriptionExpiry
        {
            get => _subscriptionExpiry;
            set { if (_subscriptionExpiry != value) { _subscriptionExpiry = value; OnPropertyChanged(); } }
        }
    }
}
