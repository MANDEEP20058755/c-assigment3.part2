using System;
using System.Linq;
using System.Xml.Linq;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace FileReadingApp
{
    public class XmlFileReader : FileReaderBase
    {
        public static void ReadXmlFile(string filePath)
        {
            Console.WriteLine("========= Read XML file ==============");
            XDocument doc = XDocument.Load(filePath);
            var books = from book in doc.Descendants("book")
                        select new Book
                        {
                            Category = book.Attribute("category").Value,
                            Title = book.Element("title").Value,
                            Author = book.Element("author").Value,
                            Year = book.Element("year").Value,
                            Price = book.Element("price").Value
                        };

            PrintTable(books);
            SaveToExcel(books.ToList(), @"C:\Users\Akashdeep Singh\Desktop\Books.xlsx");
        }

        private static void SaveToExcel(List<Book> books, string filePath)
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Books");
                worksheet.Cells[1, 1].Value = "Category";
                worksheet.Cells[1, 2].Value = "Title";
                worksheet.Cells[1, 3].Value = "Author";
                worksheet.Cells[1, 4].Value = "Year";
                worksheet.Cells[1, 5].Value = "Price";

                for (int i = 0; i < books.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = books[i].Category;
                    worksheet.Cells[i + 2, 2].Value = books[i].Title;
                    worksheet.Cells[i + 2, 3].Value = books[i].Author;
                    worksheet.Cells[i + 2, 4].Value = books[i].Year;
                    worksheet.Cells[i + 2, 5].Value = books[i].Price;
                }

                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
                Console.WriteLine($"Excel file saved to: {excelFile.FullName}");
            }
        }
    }
}