using Dapper.Domain.Dtos;
using Dapper.Application.Validators;
using Dapper.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Dapper.Application.Services.Commands
{
    public class CreateClientCommand(ClientDto client) : IRequest
    {
        public int Id;
        public string? Name = client.Name;
        public string? Surname = client.Surname;

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
        {
            private readonly IApiDbContext _context;
            private ClientDtoValidator _validator = new ClientDtoValidator();

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

                    _validator.ValidateAndThrow(client);

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
