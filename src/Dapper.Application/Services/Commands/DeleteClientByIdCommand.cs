using Dapper.Domain.Interfaces;
using MediatR;

namespace Dapper.Application.Services.Commands
{
    public class DeleteClientByIdCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
        public string? Name { get; set; }
        public string? Surname { get; set; }

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
