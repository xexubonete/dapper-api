using System.Data;

namespace Dapper.Application.Tests.Extensions
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