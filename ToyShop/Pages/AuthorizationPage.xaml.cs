using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ToyShop.Utils;
using ToyShop.Models;
using System.Windows.Controls; 

namespace ToyShop.Pages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
           
                string login = loginTb.Text;
                string password = passwordPb.Password;

                List<User> users = ExcelReader.LoadUsersFromExcel("User.xlsx");
                var user = users.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new CatalogPage());
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
          
                
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new SignUpPage());
        }

        
    }
}   