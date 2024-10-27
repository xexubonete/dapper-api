using dapper_api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace dapper_api.Models
{
    public class ApiDbContext : IApiDbContext
    {
        private string _connectionString;

        public ApiDbContext(IConfiguration configuration)
        {
            // _connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
            // Accede directamente a la variable de entorno configurada en Docker
            _connectionString = configuration["ConnectionStrings__AZURE_SQL_CONNECTIONSTRING"];
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
