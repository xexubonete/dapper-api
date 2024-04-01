using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
    {
        public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
        {
            private IApiDbContext _context;
            public GetAllClientsQueryHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    string query = "SELECT * FROM [Client]";
                    var result = await connection.QueryAsync<Client>(query);

                    return result == null ? throw new Exception("No clients") : result;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
