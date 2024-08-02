using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace FileReadingApp
{
    public class JsonFileReader : FileReaderBase
    {
        public static void ReadJsonFile(string filePath)
        {
            Console.WriteLine("========= Read JSON file ==============");
            var jsonString = File.ReadAllText(filePath);
            var bookstore = JObject.Parse(jsonString)["bookstore"]["book"];

            var books = bookstore.Select(book => new Book
            {
                Category = book["category"].ToString(),
                Title = book["title"]["text"].ToString(),
                Author = book["author"].ToString(),
                Year = book["year"].ToString(),
                Price = book["price"].ToString()
            });

            PrintTable(books);
        }
    }
}