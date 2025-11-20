using Dapper.Domain.Dtos;
using Dapper.Domain.Interfaces;
using MediatR;

namespace Dapper.Application.Services.Queries
{
    public class GetClientByIdQuery(int id) : IRequest<ClientDto?>
    {
        private readonly int _id = id;

        public class GetClientByIdQueryHandler(IApiDbContext context) : IRequestHandler<GetClientByIdQuery, ClientDto?>
        {
            private readonly IApiDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

            public async Task<ClientDto?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var sql = $"SELECT * FROM Client WHERE Id = @Id";
                    
                    // return (await connection.QueryAsync<ClientDto?>(sql, new { request.Id })).FirstOrDefault() ?? throw new ArgumentNullException(nameof(connection));
                    return new ClientDto();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the request", ex);
                }
            }        
        }
    }
}
