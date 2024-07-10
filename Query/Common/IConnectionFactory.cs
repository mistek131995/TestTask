using Microsoft.Data.SqlClient;

namespace TestTask.Query.Common;

interface IConnectionFactory
{
    SqlConnection GetConnection();
}
