using System.Windows;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;

            Loaded += async (_, _) =>
            {
                await viewModel.InitializeAsync();
            };
        }
    }
}