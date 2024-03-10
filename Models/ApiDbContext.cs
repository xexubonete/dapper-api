using dapper_api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace dapper_api.Models
{
    public class ApiDbContext : IApiDbContext
    {
        public IDbConnection CreateConnection() 
        {
            string conectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=CrudApi;TrustServerCertificate=True;Integrated Security=True;";
            return new SqlConnection(conectionString);
        }
    }
}
