using Microsoft.Data.SqlClient;

public class DataService
{

    private readonly IConfiguration _configuration;

    public DataService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ExecuteCommand(string query)
    {
        string connectionString = ConnectionStringBuilder();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }


    }
    public List<List<string>> GetDataTable(string query)
    {
        string connectionString = ConnectionStringBuilder();
        var rows = new List<List<string>>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    bool headersAdded = false;

                    while (reader.Read())
                    {
                        var cols = new List<string>();
                        var headerCols = new List<string>();

                        if (!headersAdded)
                        {
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                headerCols.Add(reader.GetName(i).ToString());
                            }
                            rows.Add(headerCols);
                            headersAdded = true;
                        }

                        var row = new List<string>();
                        for (var i = 0; i <= reader.FieldCount - 1; i++)
                        {
                            cols.Add(reader.GetValue(i).ToString());
                        }
                        rows.Add(cols);
                    }
                }
            }
        }
        return rows;
    }

    private string ConnectionStringBuilder()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = _configuration.GetValue<string>("SQL:Server");
        builder.UserID = _configuration.GetValue<string>("SQL:User");
        builder.Password = _configuration.GetValue<string>("SQL:Password");
        builder.InitialCatalog = _configuration.GetValue<string>("SQL:Database");

        var connectionString = builder.ConnectionString;
        return connectionString;
    }
}
