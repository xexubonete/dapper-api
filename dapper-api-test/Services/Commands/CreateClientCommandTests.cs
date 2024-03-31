using dapper_api.Entities;
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

        public CreateClientCommandTests()
        {
            db = new InMemoryDatabase();
            var client = new Client
            {
                Id = 2,
                Name = "Name",
                Surname = "Surname"
            };

            createClientCommand = new CreateClientCommand(client);
            _context = new Mock<IApiDbContext>();
            db.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task CreateClientCommand_Should_Return_Record()
        {
            var request = new CreateClientCommand.CreateClientCommandHandler(_context.Object);
            await request.Handle(createClientCommand, CancellationToken.None);

            db.
            Assert.That(result != null);
        }
    }
}
