using System.Data;
using System.Data.Common;

namespace dapper_api.Interfaces
{
    public interface IApiDbContext
    {
        public IDbConnection CreateConnection();
    }
}
