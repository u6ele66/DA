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
        private static string dbName = "covid_data";

        public void InsertDataInTable(string path)
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

            var fields = typeof(IFields).GetProperties().Select(f => f.Name).ToList();

            //for (int y = 0; y < height; y++)
            //{
            //    for (int x = 0; x < width; x++)
            //    {
            //        SqlCommand command = new SqlCommand($"INSERT INTO [covid_data] (" +
            //        $"{listOfFieldNames[x]}) " +
            //        $"VALUES ('{dataArr[y, x]}')", connection);
            //        command.ExecuteNonQuery();
            //    }
            //}

            SqlCommand command = new SqlCommand();

            string query = "";
            int queryCount = 0;

            string queryStart = $"INSERT INTO [{dbName}] (";

            for (int y = 0; y < height; y++)
            {
                for (int i = 0; i < width; i++)
                {
                    if(i == 0 && y == 0)
                    {
                        query = queryStart + $"{fields[i]}, ";
                    }
                    else
                    {
                        if(y != 0 && i == 0)
                        {
                            query = query + queryStart + $"{fields[i]}, ";
                        }
                        else
                        {
                            query = query + $"{fields[i]}, ";
                        }
                    }

                    if (i == width - 1)
                    {
                        query = query.Trim();
                        query = query.Remove(query.Length - 1, 1) + ")";

                        query = query + $" VALUES (";

                        for (int j = 0; j < width; j++)
                        {
                            query = query + $"'{dataArr[y, j]}', ";

                            if (j == width - 1)
                            {
                                query = query.Trim();
                                query = query.Remove(query.Length - 1, 1) + ")";
                                break;
                            }
                        }
                        if (query.EndsWith(")"))
                        {
                            queryCount++;
                            query = query + ";\n";
                            command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                            query = "";
                            continue;
                        }
                    }
                }
            }
        }
    }
}
