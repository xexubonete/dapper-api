using Dapper;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class DeleteClientByIdCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DeleteClientByIdCommand(int id)
        {
            Id = id;
        }

        public class DeleteClientByIdCommandHandler : IRequestHandler<DeleteClientByIdCommand>
        {
            private readonly IApiDbContext _context;
            public DeleteClientByIdCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = _context.CreateConnection();

                    var sql = "DELETE FROM Clients WHERE Id = @Id";

                    await connection.ExecuteAsync(sql, new { request.Id });

                }
                catch (Exception ex)
                {
                    throw new Exception("An error ocurred while processing the request", ex);
                }
            }
        }
    }
}
