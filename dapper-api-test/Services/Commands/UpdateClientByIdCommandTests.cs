using dapper_api.DTOs;
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
        ClientDTO client = new ClientDTO();

        public UpdateClientByIdCommandTests()
        {
            db = new InMemoryDatabase();
            client = new ClientDTO
            {
                Name = "Name",
                Surname = "Surname"
            };

            updateClientByIdCommand = new UpdateClientByIdCommand(client);
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task UpdateClientByIdCommand_Should_Return_Record()
        {
            // Arrange
            var request = new UpdateClientByIdCommand.UpdateClientByIdCommandHandler(_context.Object);

            // Act
            await request.Handle(updateClientByIdCommand, CancellationToken.None);

            // Assert
            _context.Verify(x => x.CreateConnection(), Times.Once());
        }
    }
}
