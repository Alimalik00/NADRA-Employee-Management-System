using System.Data.SqlClient;

internal class SqlCommand
{
    private string sqlQuery;
    private SqlConnection connection;

    public SqlCommand(string sqlQuery, SqlConnection connection)
    {
        this.sqlQuery = sqlQuery;
        this.connection = connection;
    }
}