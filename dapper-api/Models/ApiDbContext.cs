using dapper_api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace dapper_api.Models
{
    public class ApiDbContext : IApiDbContext
    {
        public IDbConnection CreateConnection()
        {
            string connectionString = "Server=sqlserver;Database=CrudApi;User Id=sa;Password=Sqlserver0001&;TrustServerCertificate=True";
            return new SqlConnection(connectionString);
        }
    }
}
