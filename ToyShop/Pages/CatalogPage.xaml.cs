using System.Collections.Generic;
using System.Windows;
using ToyShop.Utils;
using System.Windows.Controls;

namespace ToyShop.Pages
{
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();

            // Чтение из Excel
            var products = ExcelReader.LoadProductsFromExcel("Toy.xlsx");

            ProductsList.ItemsSource = products;
        }
    }
}