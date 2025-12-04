using System.Collections.ObjectModel;
using System.Linq;
using TestWpf.Models;
using TestWpf.Views;

namespace TestWpf.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel(SideBarViewModel sideBarViewModel)
        {
            SideBarViewModel = sideBarViewModel;
            Tabs = new ObservableCollection<TabItemModel>();

            // Subscribe to sidebar event
            SideBarViewModel.RequestOpenTab += OpenTab;
        }

        public SideBarViewModel SideBarViewModel { get; set; }
        public ObservableCollection<TabItemModel> Tabs { get; }

        private void OpenTab(string header)
        {
            if (Tabs.Any(t => t.Header == header)) return;

            if (header == "Users")
            {
                Tabs.Add(new TabItemModel
                {
                    Header = "Users",
                    Content = new UserViewControl
                    {
                        DataContext = SideBarViewModel
                    }
                });
            }
            else
            {
                Tabs.Add(new TabItemModel
                {
                    Header = header,
                    Content = new System.Windows.Controls.TextBlock
                    {
                        Text = $"{header} Content",
                        Margin = new System.Windows.Thickness(10)
                    }
                });
            }
        }
    }
}