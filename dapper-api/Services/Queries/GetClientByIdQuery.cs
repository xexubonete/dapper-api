﻿using Dapper;
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
                    var result = (await connection.QueryAsync<Client>(query, new { request.Id })).FirstOrDefault();

                    return result == null ? throw new Exception($"No client with Id = {request.Id}") : result;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }        
        }
    }
}
