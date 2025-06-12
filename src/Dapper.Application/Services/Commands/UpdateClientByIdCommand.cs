using Dapper.Domain.Dtos;
using Dapper.Application.Validators;
using Dapper.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Dapper.Application.Services.Commands
{
    public class UpdateClientByIdCommand(ClientDto client) : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; } = client.Name;
        public string? Surname { get; set; } = client.Surname;

        public class UpdateClientByIdCommandHandler : IRequestHandler<UpdateClientByIdCommand>
        {
            private readonly IApiDbContext _context;
            private readonly ClientDtoValidator validator = new ClientDtoValidator();
            public UpdateClientByIdCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(UpdateClientByIdCommand request, CancellationToken cancellationToken)
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

                    var sql = "UPDATE Clients SET Name = @Name, Surname = @Surname WHERE Id = @Id";

                    await connection.ExecuteAsync(sql, new { request.Id, request.Name, request.Surname });
                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
