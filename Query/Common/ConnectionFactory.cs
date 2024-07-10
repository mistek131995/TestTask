
using Microsoft.Data.SqlClient;

namespace TestTask.Query.Common;

public class ConnectionFactory(string connectionString) : IConnectionFactory
{
    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
