﻿using Dapper;
using dapper_api.DTOs;
using dapper_api.Interfaces;
using FluentValidation;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class UpdateClientByIdCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public UpdateClientByIdCommand(ClientDTO client)
        {
            Name = client.Name;
            Surname = client.Surname;
        }

        public class UpdateClientByIdCommandHandler : IRequestHandler<UpdateClientByIdCommand>
        {
            private readonly IApiDbContext _context;
            private readonly ClientDTOValidator validator = new ClientDTOValidator();
            public UpdateClientByIdCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(UpdateClientByIdCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var client = new ClientDTO
                    {
                        Name = request.Name,
                        Surname = request.Surname,
                    };

                    validator.ValidateAndThrow(client);

                    string command = $"UPDATE [Client] SET [Name]= \'{ request.Name }\', [Surname]= \'{ request.Surname }\' WHERE [Id] = { request.Id }";

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
