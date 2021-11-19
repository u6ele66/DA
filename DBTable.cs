using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class DBTable : IDBTable
    {
        private static string tableName = "covid_data";
        private static string tableNameUs = "covid_data_us";

        public void CreateTable(string path)
        {
            ISqlConn db = new SqlConn();
            SqlConnection con = db.getConnection();

            SqlCommand sqlCommand;

            if(path.EndsWith("_us"))
            {
                string query = $"CREATE TABLE {tableNameUs}" + $"(" +
                    $"{nameof(IFields_US.Province_State)} NVARCHAR(100), " +
                    $"{nameof(IFields_US.Country_Region)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Last_Update)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Lat)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Long_)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Confirmed)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Deaths)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Recovered)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Active)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.FIPS)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Incident_Rate)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Total_Test_Results)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.People_Hospitalized)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Case_Fatality_Ratio)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.UID)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.ISO3)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Testing_Rate)} NVARCHAR(100)," +
                    $"{nameof(IFields_US.Hospitalization_Rate)} NVARCHAR(100))";

                sqlCommand = new SqlCommand(query, con);

                try
                {
                    DeleteTable(tableNameUs);

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
            else
            {
                string query = $"CREATE TABLE {tableName}" + $"(" +
                    $"{nameof(IFields.FIPS)} NVARCHAR(100), " +
                    $"{nameof(IFields.Admin2)} NVARCHAR(100)," +
                    $"{nameof(IFields.Province_State)} NVARCHAR(100)," +
                    $"{nameof(IFields.Country_Region)} NVARCHAR(100)," +
                    $"{nameof(IFields.Last_Update)} NVARCHAR(100)," +
                    $"{nameof(IFields.Lat)} NVARCHAR(100)," +
                    $"{nameof(IFields.Long_)} NVARCHAR(100)," +
                    $"{nameof(IFields.Confirmed)} NVARCHAR(100)," +
                    $"{nameof(IFields.Deaths)} NVARCHAR(100)," +
                    $"{nameof(IFields.Recovered)} NVARCHAR(100)," +
                    $"{nameof(IFields.Active)} NVARCHAR(100)," +
                    $"{nameof(IFields.Combined_Key)} NVARCHAR(100)," +
                    $"{nameof(IFields.Incident_Rate)} NVARCHAR(100)," +
                    $"{nameof(IFields.Case_Fatality_Ratio)} NVARCHAR(100))";

                sqlCommand = new SqlCommand(query, con);

                try
                {
                    DeleteTable(tableName);

                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine($"Table {tableName} created");
                }
                catch
                {
                    Console.WriteLine("Error: table didnt created");
                }
            }
        }

        public void DeleteTable(string tableName)
        {
            ISqlConn db = new SqlConn();
            SqlConnection con = db.getConnection();

            string deleteQuery = $"DROP TABLE {tableName};";

            SqlCommand sqlCommandDelete = new SqlCommand(deleteQuery, con);

            try
            {
                con.Open();
                sqlCommandDelete.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                Console.WriteLine("Delete error");
            }
        }
    }
}
