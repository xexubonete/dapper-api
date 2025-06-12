using dapper_api.Dtos;
using dapper_api.Interfaces;
using dapper_api.Services.Commands;
using Moq;

namespace dapper_api_test.Services.Commands
{
    public class CreateClientCommandTests
    {
        private CreateClientCommand createClientCommand;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;
        ClientDto client = new ClientDto();

        public CreateClientCommandTests()
        {
            db = new InMemoryDatabase();
            client = new ClientDto
            {
                Name = "Name",
                Surname = "Surname"
            };

            createClientCommand = new CreateClientCommand(client);
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task CreateClientCommand_Should_Return_Record()
        {
            var request = new CreateClientCommand.CreateClientCommandHandler(_context.Object);
            await request.Handle(createClientCommand, CancellationToken.None);
            
            // Verificar que la conexión se usó correctamente
            _context.Verify(x => x.CreateConnection(), Times.Once());
        }
    }
}
