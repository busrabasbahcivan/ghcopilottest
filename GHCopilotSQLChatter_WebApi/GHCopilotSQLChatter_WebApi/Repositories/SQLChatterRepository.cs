using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GHCopilotSQLChatter_WebApi.Repositories
{
    public class SQLChatterRepository
    {
        private readonly string _connectionString;

        public SQLChatterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public class QueryResult
        {
            public List<string> Columns { get; set; }
            public List<string[]> Rows { get; set; }
            public string ErrorMessage { get; set; }
        }

        public QueryResult ExecuteQuery(string query)
        {
            //query = "SELECT TOP 5 * FROM [SalesLT].[Customer]";
            var result = new QueryResult
            {
                Columns = new List<string>(),
                Rows = new List<string[]>(),
                ErrorMessage = null,
            };

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Columns.Add(reader.GetName(i));
                            }

                            while (reader.Read())
                            {
                                var row = new string[reader.FieldCount];
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i))
                                    {
                                        row[i] = null;
                                    }
                                    else
                                    {
                                        var fieldType = reader.GetFieldType(i);
                                        if (fieldType == typeof(string))
                                        {
                                            row[i] = reader.GetString(i);
                                        }
                                        else if (fieldType == typeof(int))
                                        {
                                            row[i] = reader.GetInt32(i).ToString();
                                        }
                                        else if (fieldType == typeof(bool))
                                        {
                                            row[i] = reader.GetBoolean(i).ToString();
                                        }
                                        else if (fieldType == typeof(DateTime))
                                        {
                                            row[i] = reader.GetDateTime(i).ToString("o");
                                        }
                                        else if (fieldType == typeof(Guid))
                                        {
                                            row[i] = reader.GetGuid(i).ToString();
                                        }
                                        else
                                        {
                                            row[i] = reader.GetValue(i).ToString();
                                        }
                                    }
                                }
                                result.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                result.ErrorMessage = $"SQL Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"General Error: {ex.Message}";
            }

            return result;
        }
    }
}
