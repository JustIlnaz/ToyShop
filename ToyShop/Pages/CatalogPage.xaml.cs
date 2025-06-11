using System.Collections.Generic;
using System.Windows.Controls;
using ToyShop.Utils;

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