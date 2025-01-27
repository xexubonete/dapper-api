﻿using Dapper;
using dapper_api.DTOs;
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
        public CreateClientCommand(ClientDTO client)
        {
            Name = client.Name;
            Surname = client.Surname;
        }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
        {
            private readonly IApiDbContext _context;
            private ClientDTOValidator validator = new ClientDTOValidator();

            public CreateClientCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
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
