using MMNGS.Services.IServices;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestWpf.Commands;
using TestWpf.Models;

namespace TestWpf.ViewModels
{
    public class SideBarViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;

        // Constructor
        public SideBarViewModel(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            Users = new ObservableCollection<UserModel>();

            OpenTabCommand = new RelayCommand(OnOpenTab);

            LoadUsers();
        }

        // Observable collection to bind to UI
        public ObservableCollection<UserModel> Users { get; }

        // Command to open tabs
        public ICommand OpenTabCommand { get; }

        // Event triggered when a tab needs to be opened
        public event Action<string>? RequestOpenTab;

        private void OnOpenTab(object? parameter)
        {
            if (parameter is string header)
            {
                RequestOpenTab?.Invoke(header);
            }
        }

        // Load users from service
        private async void LoadUsers()
        {
            try
            {
                var result = await _userService.GetUserDetails();

                Users.Clear();

                foreach (var u in result)
                {
                    Users.Add(new UserModel
                    {
                        UserId = u.UserId,
                        AdminId = u.AdminId,
                        Name = u.Name,
                        Email = u.Email,
                        Phone = u.Phone,
                        PasswordHash = u.PasswordHash,
                        Address = u.Address,
                        FatherPhone = u.FatherPhone
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions properly
                // e.g., log or show message
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
