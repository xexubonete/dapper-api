using dapper_api.Entities;
using MediatR;

namespace dapper_api.Services.Queries
{
    public class GetAllClientsQuery : IRequest<List<Client>>
    {
        public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IList<Client>>
        {
            public Task<IList<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
