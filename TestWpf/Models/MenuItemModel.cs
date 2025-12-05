using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestWpf.Helpers.Enums;

namespace TestWpf.Models
{
    public class MenuItemModel : INotifyPropertyChanged
    {
        private bool _isSelected;

        public string Title { get; set; } = string.Empty;
        public TabEnum Tab { get; set; }

        // Track if this tab is selected
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
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
