using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TestWpf.Commands;
using TestWpf.Helpers.Enums;
using TestWpf.Models;

namespace TestWpf.ViewModels
{
    public class SideBarViewModel
    {
        public SideBarViewModel(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
            OpenTabCommand = new RelayCommand(OnOpenTab);

            MenuItems = new ObservableCollection<MenuItemModel>(
                Enum.GetValues(typeof(TabEnum))
                    .Cast<TabEnum>()
                    .Select(e => new MenuItemModel
                    {
                        Tab = e,
                        Title = Regex.Replace(e.ToString(), "([a-z])([A-Z])", "$1 $2")
                    })
            );
        }

        public UserViewModel UserViewModel { get; set; }

        public ObservableCollection<MenuItemModel> MenuItems { get; }

        public ICommand OpenTabCommand { get; }

        public event Action<TabEnum>? RequestOpenTab;

        private void OnOpenTab(object? parameter)
        {
            if (parameter is MenuItemModel item)
            {
                // Fire event
                RequestOpenTab?.Invoke(item.Tab);

                // Update selection
                foreach (var menuItem in MenuItems)
                    menuItem.IsSelected = menuItem == item;
            }
        }
    }
}
