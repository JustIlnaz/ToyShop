using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using ToyShop.Models;
using System.Windows.Controls;
using System.Linq;
namespace ToyShop.Utils
{
    public static class WordReader
    {
        public static List<Product> LoadProductsFromWord(string filePath)
        {
            var products = new List<Product>();

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                var table = doc.MainDocumentPart.Document.Body.Elements<Table>().First();
                var rows = table.Elements<TableRow>().Skip(1);

                foreach (var row in rows)
                {
                    var cells = row.Elements<TableCell>().ToList();
                    products.Add(new Product
                    {
                        ImagePath = cells[0].InnerText.Trim(),
                        Name = cells[1].InnerText.Trim(),
                        Description = cells[2].InnerText.Trim(),
                        Price = decimal.Parse(cells[3].InnerText.Trim()),
                        Count = int.Parse(cells[4].InnerText.Trim())
                    });
                }
            }

            return products;
        }
    }
}