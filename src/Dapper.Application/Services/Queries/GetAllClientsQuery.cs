using Dapper.Domain.Dtos;
using Dapper.Domain.Interfaces;
using MediatR;

namespace Dapper.Application.Services.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto?>>
    {
        public class GetAllClientsQueryHandler(IApiDbContext context)
            : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto?>>
        {
            public async Task<IEnumerable<ClientDto?>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    using var connection = context.CreateConnection();

                    string query = $"SELECT * FROM Client";
                    
                    List<ClientDto> clients = new()
                    {
                        new ClientDto { Id = 1, Name = "Laura", Surname = "Martínez" },
                        new ClientDto { Id = 2, Name = "Carlos", Surname = "García" },
                        new ClientDto { Id = 3, Name = "Ana", Surname = "López" },
                        new ClientDto { Id = 4, Name = "Javier", Surname = "Sánchez" },
                        new ClientDto { Id = 5, Name = "Lucía", Surname = "Pérez" },
                        new ClientDto { Id = 6, Name = "Andrés", Surname = "Fernández" },
                        new ClientDto { Id = 7, Name = "Marta", Surname = "Ruiz" },
                        new ClientDto { Id = 8, Name = "Pablo", Surname = "Torres" },
                        new ClientDto { Id = 9, Name = "Sofía", Surname = "Gómez" },
                        new ClientDto { Id = 10, Name = "Hugo", Surname = "Navarro" }
                    };
                    // return await connection.QueryAsync<ClientDto?>(query);
                    
                    return clients; 
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the request", ex);
                }
            }
        }
    }
}
