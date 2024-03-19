using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class DeleteClientByIdCommand : IRequest<Client>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DeleteClientByIdCommand(int id)
        {
            Id = id;
        }

        public class DeleteClientByIdCommandHandler : IRequestHandler<DeleteClientByIdCommand, Client>
        {
            private readonly IApiDbContext _context;
            public DeleteClientByIdCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
            {
                var connection = _context.CreateConnection();
                string command = $"DELETE FROM [dbo].[Client] WHERE [Id] = {request.Id}";
                var result = (await connection.QueryAsync(command)).First();

                return result;
            }
        }
    }
}
