using Dapper;
using dapper_api.DTOs;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Queries
{
    public class GetClientByIdQuery : IRequest<ClientDTO>
    {
        public int Id;

        public GetClientByIdQuery(int id)
        {
            Id = id;
        }

        public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
        {

            private readonly IApiDbContext _context;
            public GetClientByIdQueryHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var sql = "SELECT * FROM Clients WHERE Id = @Id";

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                    return (await connection.QueryAsync<ClientDTO>(sql, new { request.Id })).FirstOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo

                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }        
        }
    }
}
