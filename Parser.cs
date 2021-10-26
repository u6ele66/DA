using Microsoft.VisualBasic.FileIO;
using System;

namespace lw1
{
    class Parser
    {
        public static TextFieldParser SetParser(string path)
        {
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;
            return csvParser;
        }

        public static string[] GetColumnsNames(string path)
        {
            string[] columns = SetParser(path).ReadFields();
            string[] columnList = new string[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                columnList[i] = columns[i];
            }
            return columnList;
        }

        public static int GetColumnsAmount(string path)
        {
            return GetColumnsNames(path).Length;
        }

        public static string[] GetAllData(string path, string dataLine)
        {
            string[] dataList = new string[GetColumnsAmount(path)];
            int i = 0;
            foreach (var item in dataLine.Split(','))
            {
                dataList[i] = item;
                i++;
                if (dataList[dataList.Length - 1] != null)
                {
                    break;
                }
            }

            return dataList;
        }

        public static void GetParsedData(string path, TextFieldParser parsedFile)
        {
            string[] fields = new string[GetColumnsAmount(path)];

            string dataLine;
            var columns = GetColumnsNames(path);

            while ((dataLine = parsedFile.ReadLine()) != null)
            {
                var allData = GetAllData(path, dataLine);

                for (int i = 0; i < columns.Length; i++)
                {
                    foreach (var data in allData)
                    {
                        Console.WriteLine($"{columns[i]}: {data}");
                        i++;
                    }
                }
            }
        }
    }
}
