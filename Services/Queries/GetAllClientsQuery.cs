using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Queries
{
    public class GetAllClientsQuery : IRequest<IList<Client>>
    {
        public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IList<Client>>
        {
            private readonly IApiDbContext _context;

            public Task<IList<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                var connectionString = _context.CreateConnection();

                throw new NotImplementedException();
            }
        }
    }
}
