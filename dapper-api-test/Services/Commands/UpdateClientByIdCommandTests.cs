using System.Data;
using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using dapper_api.Services.Commands;
using Moq;

namespace dapper_api_test.Services.Commands
{
    public class UpdateClientByIdCommandTests
    {
        private UpdateClientByIdCommand updateClientByIdCommand;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;
        Client client = new Client();

        public UpdateClientByIdCommandTests()
        {
            db = new InMemoryDatabase();
            client = new Client
            {
                Id = 2,
                Name = "Name",
                Surname = "Surname"
            };

            updateClientByIdCommand = new UpdateClientByIdCommand(client);
            _context = new Mock<IApiDbContext>();
            db.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task UpdateClientByIdCommand_Should_Return_Record()
        {
            var executeAsyncMoq = new Mock<IDbConnection>();
            var request = new UpdateClientByIdCommand.UpdateClientByIdCommandHandler(_context.Object);
            await request.Handle(updateClientByIdCommand, CancellationToken.None);

            executeAsyncMoq.Verify(x => x.ExecuteAsync("", null, null, null, null), Times.Once);
        }
    }
}
