using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace lw1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Lenovo\Desktop\COVID-19-master\COVID-19-master\csse_covid_19_data\csse_covid_19_daily_reports\01-02-2021.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    string FIPS = fields[0];
                    string Admin2 = fields[1];
                    string Province_State = fields[2];
                    string Country_Region = fields[3];
                    string Last_Update = fields[4];
                    string Lat = fields[5];
                    string Long_ = fields[6];
                    string Confirmed = fields[7];
                    string Deaths = fields[8];
                    string Recovered = fields[9];
                    string Active = fields[10];
                    string Combined_Key = fields[11];
                    string Incident_Rate = fields[12];
                    string Case_Fatality_Ratio = fields[13];
                }
            }
        }
    }
}
