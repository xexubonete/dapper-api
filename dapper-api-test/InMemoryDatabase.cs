using dapper_api.Entities;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace dapper_api_test
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance, true);

        public IDbConnection OpenConnection() => this.dbFactory.OpenDbConnection();

        public void Insert<T>(IEnumerable<T> items)
        {
            using (var db = this.OpenConnection())
            {
                db.CreateTableIfNotExists<T>();
                foreach (var item in items)
                {
                    db.Insert(item);
                }
            }
        }

        public void CreateDatabaseTest(InMemoryDatabase db)
        {
            var client = new Client
                {
                    Id = 1,
                    Name = "Test",
                    Surname = "Test"
                };

            IEnumerable<Client> clients = new List<Client> { client };
            db.Insert(clients);
        }
    }
}
