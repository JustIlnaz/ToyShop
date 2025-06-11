using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using ToyShop.Models;

namespace ToyShop.Utils
{
    public static class ExcelReader
    {
        
        static ExcelReader()
        {
            ExcelPackage.License.SetNonCommercialOrganization("ilnaz");
        }


        public static List<Product> LoadProductsFromExcel(string filePath)
        {
            var products = new List<Product>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets[0]; // первая таблица
                int rowCount = ws.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // пропускаем заголовок
                {
                    products.Add(new Product
                    {
                        ImagePath = ws.Cells[row, 1].Text.Trim(),
                        Name = ws.Cells[row, 2].Text.Trim(),
                        Description = ws.Cells[row, 3].Text.Trim(),
                        Price = decimal.Parse(ws.Cells[row, 4].Text.Trim()),
                        Count = int.Parse(ws.Cells[row, 5].Text.Trim())
                    });
                }
            }

            return products;
        }

        public static List<User> LoadUsersFromExcel(string filePath)
        {
            var users = new List<User>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets[0];
                int rowCount = ws.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    users.Add(new User
                    {
                        LastName = ws.Cells[row, 1].Text.Trim(),
                        FirstName = ws.Cells[row, 2].Text.Trim(),
                        MiddleName = ws.Cells[row, 3].Text.Trim(),
                        Login = ws.Cells[row, 4].Text.Trim(),
                        Password = ws.Cells[row, 5].Text.Trim(),
                        Role = ws.Cells[row, 6].Text.Trim()
                    });
                }
            }

            return users;
        }

        public static void SaveUserToExcel(User user)
        {
            var fileInfo = new FileInfo("User.xlsx");
            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws;

                // Проверяем, есть ли уже листы
                if (package.Workbook.Worksheets.Count == 0)
                {
                    ws = package.Workbook.Worksheets.Add("Sheet1");

                    // Добавляем заголовки, если создаём новый файл
                    ws.Cells[1, 1].Value = "Фамилия";
                    ws.Cells[1, 2].Value = "Имя";
                    ws.Cells[1, 3].Value = "Отчество";
                    ws.Cells[1, 4].Value = "Логин";
                    ws.Cells[1, 5].Value = "Пароль";
                    ws.Cells[1, 6].Value = "Роль";
                }
                else
                {
                    ws = package.Workbook.Worksheets[0];
                }

                int nextRow = ws.Dimension?.Rows + 1 ?? 2; // Если нет данных, начинаем с 2 строки

                ws.Cells[nextRow, 1].Value = user.LastName;
                ws.Cells[nextRow, 2].Value = user.FirstName;
                ws.Cells[nextRow, 3].Value = user.MiddleName;
                ws.Cells[nextRow, 4].Value = user.Login;
                ws.Cells[nextRow, 5].Value = user.Password;
                ws.Cells[nextRow, 6].Value = user.Role;

                package.Save();
            }
        }
    }
}