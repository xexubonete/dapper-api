using dapper_api.Dtos;
using Dapper;
using dapper_api.Interfaces;
using FluentValidation;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class CreateClientCommand(ClientDto client) : IRequest
    {
        public int Id;
        public string? Name = client.Name;
        public string? Surname = client.Surname;

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
        {
            private readonly IApiDbContext _context;
            private ClientDtoValidator validator = new ClientDtoValidator();

            public CreateClientCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var client = new ClientDto
                    {
                        Name = request.Name,
                        Surname = request.Surname,
                    };

                    validator.ValidateAndThrow(client);

                    var sql = "INSERT INTO Clients (Name, Surname) VALUES (@Name, @Surname)";

                    await connection.ExecuteAsync(sql, new { request.Name, request.Surname });
                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
