using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace lw1
{
    class Program
    {
        static string mainPath = @"..\..\..\..\..\COVID-19-master\COVID-19-master\csse_covid_19_data\csse_covid_19_daily_reports";
        //static string mainPathUs = @"..\..\..\..\..\COVID-19-master\COVID-19-master\csse_covid_19_data\csse_covid_19_daily_reports_us";
        static string[] fileArr = Directory.GetFiles($@"{mainPath}", "*.csv");

        public static void GetParsedData(string path, TextFieldParser parsedFile)
        {
            string[] fields = new string[Parser.GetColumnsAmount(path)];

            string dataLine;
            var columns = Parser.GetColumnsNames(path);

            while ((dataLine = parsedFile.ReadLine()) != null)
            {
                var allData = Parser.GetAllData(path, dataLine);

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
                var parsedFile = Parser.SetParser(actualPath);
                parsedFile.ReadLine();

                GetParsedData(actualPath, parsedFile);
            }
        }
    }
}
