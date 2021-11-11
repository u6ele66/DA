﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class DBTable : IDBTable
    {
       public void CreateTable()
        {
            ISqlConn db = new SqlConn();
            SqlConnection con = db.getConnection();

            string query = "CREATE TABLE covid_data" + $"({nameof(IFields.FIPS)} INT, " +
                $"{nameof(IFields.Admin2)} NVARCHAR(100)," +
                $"{nameof(IFields.Province_State)} NVARCHAR(100)," +
                $"{nameof(IFields.Country_Region)} NVARCHAR(100)," +
                $"{nameof(IFields.Last_Update)} DATETIME," +
                $"{nameof(IFields.Lat)} NVARCHAR(100)," +
                $"{nameof(IFields.Long_)} NVARCHAR(100)," +
                $"{nameof(IFields.Confirmed)} INT," +
                $"{nameof(IFields.Deaths)} INT," +
                $"{nameof(IFields.Recovered)} INT," +
                $"{nameof(IFields.Active)} INT," +
                $"{nameof(IFields.Combined_Key)} NVARCHAR(100)," +
                $"{nameof(IFields.Incident_Rate)} NVARCHAR(100)," +
                $"{nameof(IFields.Case_Fatality_Ratio)} NVARCHAR(100))";
            SqlCommand sqlCommand = new SqlCommand(query, con);

            try
            {
                DeleteTable();

                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Table created");
            }
            catch
            {
                Console.WriteLine("Error: table didnt created");
            }
        }

        public void DeleteTable()
        {
            ISqlConn db = new SqlConn();
            SqlConnection con = db.getConnection();

            string deleteQuery = "DROP TABLE dbo.covid_data;";

            SqlCommand sqlCommandDelete = new SqlCommand(deleteQuery, con);

            try
            {
                con.Open();
                sqlCommandDelete.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Table deleted");
            }
            catch
            {
                Console.WriteLine("Error: table didnt deleted");
            }
        }
    }
}