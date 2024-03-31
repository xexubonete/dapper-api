using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Server.HttpSys;

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
                var connection = _context.CreateConnection();

                string query = $"SELECT * FROM [Client] WHERE [Id] = \'{request.Id}\' ";
                var result = (await connection.QueryAsync<Client>(query)).First();

                return result;
            }        
        }
    }
}
