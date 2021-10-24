using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace lw1
{
    class Program
    {
        static string mainPath = @"..\..\..\..\..\COVID-19-master\COVID-19-master\csse_covid_19_data\csse_covid_19_daily_reports";
        static string mainPathUs = @"..\..\..\..\..\COVID-19-master\COVID-19-master\csse_covid_19_data\csse_covid_19_daily_reports_us";
        static string[] fileArr = Directory.GetFiles($@"{mainPath}", "*.csv");

        public static TextFieldParser SetParser(string path)
        {
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;
            return csvParser;
        }

        public static string[] GetColumnList(string path)
        {
            string[] columns;
            columns = SetParser(path).ReadFields();
            return columns;
        }

        public static string[] GetColumnsNames(string path)
        {
            string[] titles = GetColumnList(path.ToString()); //берем первый(0) элемент, потому что названия колонок во всех таблицах одни и те же.
            string[] columnList = new string[titles.Length];
            for (int i = 0; i < titles.Length; i++)
            {
                columnList[i] = titles[i];
            }

            return columnList;
        }

        public static string[] GetAllData(string path, string dataLine)
        {
            string[] dataList = new string[GetColumnsNames(path).Length];
            int i = 0;
            foreach (var item in dataLine.Split(','))
            {
                dataList[i] = item;
                i++;
                if(dataList[dataList.Length-1] != null)
                {
                    break;
                }
            }

            return dataList;
        }

        public static void GetParsedData(string path, TextFieldParser parsedFile)
        {
            string[] fields = new string[GetColumnsNames(path).Length];

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

        static void Main(string[] args) 
        {
            foreach (var file in fileArr)
            {
                var actualPath = file.ToString();
                var parsedFile = SetParser(actualPath);
                parsedFile.ReadLine();

                GetParsedData(actualPath, parsedFile);
            }
        }
    }
}
