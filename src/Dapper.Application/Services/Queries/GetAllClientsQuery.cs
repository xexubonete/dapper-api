using Dapper.Domain.Dtos;
using Dapper.Domain.Interfaces;
using MediatR;

namespace Dapper.Application.Services.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto?>>
    {
        public class GetAllClientsQueryHandler(IApiDbContext context)
            : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto?>>
        {
            public async Task<IEnumerable<ClientDto?>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = context.CreateConnection();

                    string query = $"SELECT * FROM Client";

                    return await connection.QueryAsync<ClientDto?>(query);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the request", ex);
                }
            }
        }
    }
}
