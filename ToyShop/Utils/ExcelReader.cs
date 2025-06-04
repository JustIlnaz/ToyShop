using ClosedXML.Excel;
using System.Collections.Generic;
using ToyShop.Models;
using System.Windows.Controls;
using System.Linq;
namespace ToyShop.Utils
{
    public static class ExcelReader
    {
        public static List<Product> LoadProductsFromExcel(string filePath)
        {
            var products = new List<Product>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    products.Add(new Product
                    {
                        ImagePath = row.Cell(1).Value.ToString(),
                        Name = row.Cell(2).Value.ToString(),
                        Description = row.Cell(3).Value.ToString(),
                        Price = decimal.Parse(row.Cell(4).Value.ToString()),
                        Count = int.Parse(row.Cell(5).Value.ToString())
                    });
                }
            }
            return products;
        }

        public static List<User> LoadUsersFromExcel(string filePath)
        {
            var users = new List<User>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    users.Add(new User
                    {
                        LastName = row.Cell(1).Value.ToString(),
                        FirstName = row.Cell(2).Value.ToString(),
                        MiddleName = row.Cell(3).Value.ToString(),
                        Login = row.Cell(4).Value.ToString(),
                        Password = row.Cell(5).Value.ToString(),
                        Role = row.Cell(6).Value.ToString()
                    });
                }
            }
            return users;
        }

        public static void SaveUserToExcel(User user)
        {
            using (var workbook = new XLWorkbook("User.xlsx"))
            {
                var ws = workbook.Worksheet(1);
                var newRow = ws.LastRowUsed().RowBelow();
                newRow.Cell(1).Value = user.LastName;
                newRow.Cell(2).Value = user.FirstName;
                newRow.Cell(3).Value = user.MiddleName;
                newRow.Cell(4).Value = user.Login;
                newRow.Cell(5).Value = user.Password;
                newRow.Cell(6).Value = user.Role;
                workbook.Save();
            }
        }
    }
}