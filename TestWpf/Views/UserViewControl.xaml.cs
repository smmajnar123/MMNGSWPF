using System.Windows;
using System.Windows.Controls;

namespace TestWpf.Views
{
    public partial class UserViewControl : UserControl
    {
        public UserViewControl()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            PopupOverlay.Visibility = Visibility.Visible;
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem == null)
            {
                MessageBox.Show("Select a user to edit.");
                return;
            }

            PopupOverlay.Visibility = Visibility.Visible;
        }

        //private void ClosePopup_Click(object sender, RoutedEventArgs e)
        //{
        //    PopupOverlay.Visibility = Visibility.Collapsed;
        //}

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.IsEnabled = UserGrid.SelectedItem != null;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // Implement search logic here
        }
    }
}
