using System;
using System.Windows;
using System.Windows.Controls;

namespace TestWpf.Views
{
    public partial class UserPupUpViewControl : UserControl
    {
        public UserPupUpViewControl()
        {
            InitializeComponent();
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from input fields
            MessageBox.Show("Save clicked! (No actual saving logic)");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var parentGrid = this.Parent as Grid;
            while (parentGrid != null && parentGrid.Name != "PopupOverlay")
            {
                parentGrid = parentGrid.Parent as Grid;
            }

            if (parentGrid != null)
            {
                parentGrid.Visibility = Visibility.Collapsed;
            }
        }
    }

    
}
