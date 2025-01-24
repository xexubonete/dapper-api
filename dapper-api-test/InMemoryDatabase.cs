using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace dapper_api_test
{
    public class InMemoryDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;

        public InMemoryDatabase()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            CreateTable();
        }

        private void CreateTable()
        {
            var sql = @"
                CREATE TABLE Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Surname TEXT NOT NULL
                )";
            
            _connection.Execute(sql);
        }

        public IDbConnection OpenConnection()
        {
            return _connection;
        }

        public static void CreateDatabaseTest(InMemoryDatabase db)
        {
            var sql = "INSERT INTO Clients (Name, Surname) VALUES (@Name, @Surname)";
            var client = new { Name = "Test", Surname = "Test" };
            
            db.OpenConnection().Execute(sql, client);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
