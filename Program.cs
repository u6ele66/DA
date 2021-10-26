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

        static void Main(string[] args)
        {
            foreach (var file in fileArr)
            {
                var actualPath = file.ToString();
                var parsedFile = Parser.SetParser(actualPath);
                parsedFile.ReadLine();

                Parser.GetParsedData(actualPath, parsedFile);
            }
        }
    }
}
