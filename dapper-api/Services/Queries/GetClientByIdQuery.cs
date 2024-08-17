using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id;

        public GetClientByIdQuery(int id)
        {
            Id = id;
        }

        public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
        {

            private readonly IApiDbContext _context;
            public GetClientByIdQueryHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    string query = $"SELECT * FROM [Client] WHERE [Id] = \'{request.Id}\' ";

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                    return (await connection.QueryAsync<Client>(query, new { request.Id })).FirstOrDefault();
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
