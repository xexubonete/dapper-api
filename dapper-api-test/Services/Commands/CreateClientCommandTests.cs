using System.Data;
using dapper_api.Entities;
using dapper_api.DTOs;
using dapper_api.Interfaces;
using dapper_api.Services.Commands;
using Moq;
using ServiceStack.OrmLite.Dapper;
using ServiceStack.DataAnnotations;

namespace dapper_api_test.Services.Commands
{
    public class CreateClientCommandTests
    {
        private CreateClientCommand createClientCommand;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;
        ClientDTO client = new ClientDTO();

        public CreateClientCommandTests()
        {
            db = new InMemoryDatabase();
            client = new ClientDTO
            {
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
            var executeAsyncMoq = new Mock<IDbConnection>();
            var request = new CreateClientCommand.CreateClientCommandHandler(_context.Object);
            await request.Handle(createClientCommand, CancellationToken.None);

            executeAsyncMoq.Verify(x => x.ExecuteAsync("", null, null, null, null), Times.Once);
        }
    }
}
