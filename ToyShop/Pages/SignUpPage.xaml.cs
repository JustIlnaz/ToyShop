using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ToyShop.Utils;
using ToyShop.Models;

namespace ToyShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string login = loginTb.Text;
            string password = passwordPb.Password;
            string repeatPassword = RepeatPasswordPb.Password;

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            var users = ExcelReader.LoadUsersFromExcel("User.xlsx");
            if (users.Any(u => u.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }

            ExcelReader.SaveUserToExcel(new User
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = "",
                Login = login,
                Password = password,
                Role = "C"
            });

            MessageBox.Show("Регистрация успешна!");
            NavigationService.GoBack();
        }
    }
}