using System.Data;

namespace Dapper.Domain.Interfaces
{
    public interface IApiDbContext
    {
        public IDbConnection CreateConnection();
    }
}
