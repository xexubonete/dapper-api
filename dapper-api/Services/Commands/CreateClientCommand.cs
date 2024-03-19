using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace dapper_api.Services.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        public int? Id;
        public string? Name;
        public string? Surname;
        public CreateClientCommand(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
        }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
        {
            private readonly IApiDbContext _context;
            public CreateClientCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var connection = _context.CreateConnection();
                string command = $"INSERT INTO [dbo].[Client] ([Id], [Name], [Surname]) VALUES ({request.Id}, \'{request.Name}\', \'{request.Surname}\');";
                var result = (await connection.QueryAsync(command)).First();
                
                return result;
            }
        }
    }
}
