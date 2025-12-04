using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestWpf.Models
{

    public class UserModel : INotifyPropertyChanged
    {
        private int _userId;
        private int _adminId;
        private string _name = null!;
        private string? _email;
        private string? _phone;
        private string _passwordHash = null!;
        private string? _address;
        private string? _fatherPhone;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int UserId
        {
            get => _userId;
            set { _userId = value; OnPropertyChanged(); }
        }

        public int AdminId
        {
            get => _adminId;
            set { _adminId = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string? Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string? Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(); }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set { _passwordHash = value; OnPropertyChanged(); }
        }

        public string? Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public string? FatherPhone
        {
            get => _fatherPhone;
            set { _fatherPhone = value; OnPropertyChanged(); }
        }
    }
}
