using System.Data.SqlClient;

namespace lw1
{
    interface ISqlConn
    {
        public void openConnection();
        public void closeConnection();
        public SqlConnection getConnection();
    }
}
