using System.Windows;

namespace ToyShop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Навигация на AuthorizationPage при запуске
            MainFrame.Navigate(new Pages.AuthorizationPage());
        }
    }
}z