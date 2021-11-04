using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class DBTable
    {
       public void CreateTable()
        {
            ISqlConn db = new SqlConn();
            SqlConnection con = db.getConnection();

            string query = "CREATE TABLE covid_data" + "(FIPS INT, " +
                "Admin2 NVARCHAR(20)," +
                "Province_State NVARCHAR(20)," +
                "Country_Region NVARCHAR(20)," +
                "Last_Update DATETIME," +
                "Lat FLOAT," +
                "Long_ FLOAT," +
                "Confirmed INT," +
                "Deaths INT," +
                "Recovered INT," +
                "Active INT," +
                "Combined_Key NVARCHAR(20)," +
                "Incident_Rate FLOAT," +
                "Case_Fatality_Ratio FLOAT)";
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
