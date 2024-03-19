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
                var connection = _context.CreateConnection();

                string command = $"UPDATE [dbo].[Client] SET [Name]= {request.Name}, [Surname])= {request.Surname} WHERE [Id] = {request.Id}";
                var result = (await connection.QueryAsync(command)).First();

                return result;
            }
        }
    }
}
