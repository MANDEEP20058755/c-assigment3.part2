using Microsoft.VisualBasic;
using System;

namespace FileReadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = @"/Users/mssaini/C#assignmentpart2/ConsoleApp1/Books.xml";
            string jsonFilePath = @"/Users/mssaini/C#assignmentpart2/ConsoleApp1/Books.json";
            string csvFilePath = @"/Users/mssaini/C#assignmentpart2/ConsoleApp1/Books.csv";

            XmlFileReader.ReadXmlFile(xmlFilePath);
            Console.WriteLine();

            JsonFileReader.ReadJsonFile(jsonFilePath);
            Console.WriteLine();

            CsvFileReader.ReadCsvFile(csvFilePath);
        }
    }
}