using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TestWpf.Helpers.Enums;
using TestWpf.Models;
using TestWpf.Views;

namespace TestWpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(SideBarViewModel sideBarViewModel)
        {
            SideBarViewModel = sideBarViewModel;
            Tabs = new ObservableCollection<ContentTabItemModel>();
            SideBarViewModel.RequestOpenTab += OpenTab;
        }

        public SideBarViewModel SideBarViewModel { get; set; }
        public ObservableCollection<ContentTabItemModel> Tabs { get; }

        private int _selectedIndex;
        public int SelectedTabIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                    UpdateSidebarSelection();
                }
            }
        }

        private void OpenTab(TabEnum header)
        {
            var existingTab = Tabs.FirstOrDefault(t => t.Header == header);
            if (existingTab != null)
            {
                SelectedTabIndex = Tabs.IndexOf(existingTab);
                return;
            }

            ContentTabItemModel newTab = header switch
            {
                TabEnum.Users => CreateUserTab(),
                TabEnum.UserProfiles => CreateUserProfilesTab(),
                _ => new ContentTabItemModel
                {
                    Header = header,
                    Content = new System.Windows.Controls.TextBlock
                    {
                        Text = $"{header} Content",
                        Margin = new System.Windows.Thickness(10)
                    }
                }
            };

            Tabs.Add(newTab);
            SelectedTabIndex = Tabs.IndexOf(newTab);
        }

        private void UpdateSidebarSelection()
        {
            if (SelectedTabIndex < 0 || SelectedTabIndex >= Tabs.Count) return;

            var activeTab = Tabs[SelectedTabIndex].Header;

            foreach (var item in SideBarViewModel.MenuItems)
                item.IsSelected = item.Tab == activeTab;
        }

        private ContentTabItemModel CreateUserTab()
        {
            SideBarViewModel.UserViewModel.LoadUsers();
            return new ContentTabItemModel
            {
                Header = TabEnum.Users,
                Content = new UserViewControl
                {
                    DataContext = SideBarViewModel.UserViewModel
                }
            };
        }

        private ContentTabItemModel CreateUserProfilesTab()
        {
            return new ContentTabItemModel
            {
                Header = TabEnum.UserProfiles,
                Content = new UserViewControl
                {
                    DataContext = SideBarViewModel.UserViewModel
                }
            };
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
