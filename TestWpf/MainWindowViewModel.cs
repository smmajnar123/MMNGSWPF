using Microsoft.EntityFrameworkCore;
using MMNGS.DataAccess.Models;
using MMNGS.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TestWpf.Models;
using TestWpf.ViewModels;

namespace TestWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region members
        private readonly IAdminService _adminService;
        public event PropertyChangedEventHandler? PropertyChanged;
        private HeaderViewModel? _headerViewModel;
        private MainViewModel? _mainViewModel;
        #endregion

        #region constructor 
        public MainWindowViewModel(IAdminService adminService, MainViewModel mainViewModel, HeaderViewModel headerViewModel)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _mainViewModel = mainViewModel;
            _headerViewModel = headerViewModel;
        }
        #endregion

        #region Properties
        public HeaderViewModel HeaderViewModel
        {
            get
            {
                return _headerViewModel;
            }

            set
            {
                _headerViewModel = value;
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return _mainViewModel;
            }

            set
            {
                _mainViewModel = value;
            }
        }
        #endregion

        #region Methods 
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task InitializeAsync()
        {
            await LoadAdminDetailsAsync(1);
        }

        private async Task LoadAdminDetailsAsync(int adminId)
        {

            try
            {
                var admin = await _adminService.GetAdminDetails(adminId);

                if (admin != null)
                {
                    HeaderViewModel.AdminProfile.Name = admin.Name;
                    HeaderViewModel.AdminProfile.Email = admin.Email;
                    HeaderViewModel.AdminProfile.MessName = admin.MessName;
                    HeaderViewModel.AdminProfile.Address = admin.Address;
                    HeaderViewModel.AdminProfile.PhoneNumber = admin.Phone;
                    if (admin.Subscription != null)
                    {
                        HeaderViewModel.AdminProfile.Duration = admin.Subscription.DurationMonths; // example
                        HeaderViewModel.AdminProfile.Price = admin.Subscription.Price; // example
                        HeaderViewModel.AdminProfile.SubscriptionExpiry = (DateOnly)admin.SubscriptionExpiry;
                    }  
                }
            }
            finally
            {
            }
        }
        #endregion
    }
}
