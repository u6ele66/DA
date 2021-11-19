using System.Data.SqlClient;


namespace lw1
{
    class SqlConn : ISqlConn
    {
        private static string dataSource = @"U6ELE66\U6ELE66NEW";
        private static string dbName = "covid";
        private static string connString = @"Data Source=" + dataSource + ";Initial Catalog=" + dbName + ";Integrated Security=True";

        SqlConnection _sqlConnection = new SqlConnection(connString);

        public void openConnection()
        {
            if(_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return _sqlConnection;
        }
    }
}
