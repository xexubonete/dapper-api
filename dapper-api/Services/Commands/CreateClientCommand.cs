using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using FluentValidation;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class CreateClientCommand : IRequest
    {
        public int Id;
        public string? Name;
        public string? Surname;
        public CreateClientCommand(Client client)
        {
            Name = client.Name;
            Surname = client.Surname;
        }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
        {
            private readonly IApiDbContext _context;
            private ClientValidator validator = new ClientValidator();

            public CreateClientCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
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

                    validator.ValidateAndThrow(client);

                    string command = $"INSERT INTO [Client] ([Name], [Surname]) VALUES ( \'{client.Name}\', \'{client.Surname}\');";

                    await connection.ExecuteAsync(command, new { request.Id, request.Name, request.Surname });

                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
