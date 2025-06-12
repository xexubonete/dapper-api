using Dapper.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Dapper.Infrastructure.Models
{
    public class ApiDbContext : IApiDbContext
    {
        private string _connectionString;

        public ApiDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING") ?? 
                throw new InvalidOperationException("'AZURE_SQL_CONNECTIONSTRING' it is not configured");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
