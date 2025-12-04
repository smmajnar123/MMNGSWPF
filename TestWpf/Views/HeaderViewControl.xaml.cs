using System.Windows;
using System.Windows.Controls;

namespace TestWpf.Views
{
    public partial class HeaderViewControl : UserControl
    {
        public HeaderViewControl()
        {
            InitializeComponent();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle Popup
            UserPopup.IsOpen = !UserPopup.IsOpen;
        }
    }
}
