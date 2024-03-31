using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class UpdateClientByIdCommand : IRequest<Client>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public UpdateClientByIdCommand(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
        }

        public class UpdateClientByIdCommandHandler : IRequestHandler<UpdateClientByIdCommand, Client>
        {
            private readonly IApiDbContext _context;
            public UpdateClientByIdCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(UpdateClientByIdCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var client = new Client
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Surname = request.Surname,
                    };
                    string command = $"UPDATE [Client] SET [Name]= \'{ request.Name }\', [Surname]= \'{ request.Surname }\' WHERE [Id] = { request.Id }";

                    await connection.ExecuteAsync(command, new { request.Id, request.Name, request.Surname });

                    return client;

                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
