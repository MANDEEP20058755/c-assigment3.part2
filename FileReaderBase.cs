using System;
using System.Collections.Generic;
using System.Linq;

namespace FileReadingApp
{
    public abstract class FileReaderBase
    {
        protected static void PrintTable(IEnumerable<Book> data)
        {
            var properties = typeof(Book).GetProperties();
            var columnNames = properties.Select(p => p.Name).ToArray();
            var rows = data.Select(item => properties.Select(p => p.GetValue(item, null)?.ToString()).ToArray()).ToList();

            PrintAlignedTable(columnNames, rows);
        }

        protected static void PrintDynamicTable(IEnumerable<dynamic> data)
        {
            var rows = data.Select(row => ((IDictionary<string, object>)row).Values.Select(value => value?.ToString()).ToArray()).ToList();
            var columnNames = ((IDictionary<string, object>)data.First()).Keys.ToArray();

            PrintAlignedTable(columnNames, rows);
        }

        private static void PrintAlignedTable(string[] columnNames, List<string[]> rows)
        {
            int[] columnWidths = new int[columnNames.Length];

            for (int i = 0; i < columnNames.Length; i++)
            {
                columnWidths[i] = columnNames[i].Length;
            }

            foreach (var row in rows)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i]?.Length > columnWidths[i])
                    {
                        columnWidths[i] = row[i].Length;
                    }
                }
            }

            PrintLine(columnNames, columnWidths);
            foreach (var row in rows)
            {
                PrintLine(row, columnWidths);
            }
        }

        private static void PrintLine(string[] columns, int[] columnWidths)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                Console.Write(columns[i].PadRight(columnWidths[i] + 2));
            }
            Console.WriteLine();
        }
    }
}