using Dapper;
using System.Data;

namespace dapper_api_test.Extensions
{
    public static class DapperExtensions
    {
        public static void CreateTableIfNotExists<T>(this IDbConnection connection) where T : class
        {
            const string sql = @"
                CREATE TABLE IF NOT EXISTS Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Surname TEXT NOT NULL
                )";
            
            connection.Execute(sql);
        }
    }
}