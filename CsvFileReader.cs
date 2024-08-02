using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace FileReadingApp
{
    public class CsvFileReader : FileReaderBase
    {
        public static void ReadCsvFile(string filePath)
        {
            Console.WriteLine("========= Read CSV file ==============");
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<dynamic>().ToList();
                PrintDynamicTable(records);
            }
        }
    }
}