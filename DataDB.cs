using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class DataDB : IDataDB
    {
        private static string langToEng = "SET LANGUAGE ENGLISH";
        private static string dbName = "";
        private static string tableName = "covid_data";
        private static string tableNameUs = "covid_data_us";

        public void InsertDataInTable(string path, string directory)
        {
            ISqlConn newConn = new SqlConn();
            newConn.openConnection();
            var connection = newConn.getConnection();

            SqlCommand toEng = new SqlCommand(langToEng, connection);

            toEng.ExecuteNonQuery();

            IFileIO file = new FileIO();

            var dataArr = file.ReadFile(path);

            int height = dataArr.GetLength(0);
            int width = dataArr.GetLength(1);

            List<string> fields = new List<string>();

            if(directory.EndsWith("_us"))
            {
                fields = typeof(IFields_US).GetProperties().Select(f => f.Name).ToList();
                dbName = tableNameUs;
            }
            else
            {
                fields = typeof(IFields).GetProperties().Select(f => f.Name).ToList();
                dbName = tableName;
            }

            SqlCommand command = new SqlCommand();

            string query = "";
            string queryFields = "";
            int queryCount = 0;

            string queryStart = $"INSERT INTO [{dbName}] (";

            for(int i = 0; i < width; i++)
            {
                if (i == 0)
                {
                    queryFields = queryStart + $"{fields[i]}, ";
                }
                else
                {
                    if (i == 0)
                    {
                        queryFields = queryFields + queryStart + $"{fields[i]}, ";
                    }
                    else
                    {
                        if (i > fields.Count - 1)
                        {
                            queryFields = queryFields.Trim();
                            queryFields = queryFields.Remove(queryFields.Length - 1, 1) + ") ";
                            break;
                        }
                        queryFields = queryFields + $"{fields[i]}, ";
                    }
                }
                if (i == width - 1)
                {
                    queryFields = queryFields.Trim();
                    queryFields = queryFields.Remove(queryFields.Length - 1, 1) + ") ";
                }
            }

            for (int y = 0; y < height; y++)
            {
                query = query + $" VALUES (";
                for (int j = 0; j < width; j++)
                {
                    if(j > fields.Count)
                    {
                        break;
                    }
                    query = query + $"'{dataArr[y, j]}', ";

                    if (j == width - 1)
                    {
                        query = query.Trim();
                        query = query.Remove(query.Length - 1, 1) + ");\n";
                        break;
                    }
                }
                if (query.EndsWith(");\n"))
                {
                    queryCount++;
                    //query = query + ";\n";
                    query = queryFields + query;
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    query = "";
                    continue;
                }
            }
        }
    }
}
