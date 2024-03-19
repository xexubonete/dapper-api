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
                var connection = _context.CreateConnection();

                string query = "SELECT * FROM [dbo].[Client]";
                IEnumerable<Client>? result = await connection.QueryAsync<Client>(query);

                return result;
            }
        }
    }
}
