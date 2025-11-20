using Dapper.Application.Services.Commands;
using Dapper.Domain.Dtos;
using Dapper.Domain.Interfaces;
using Moq;

namespace Dapper.Application.Tests.Services.Commands
{
    public class UpdateClientByIdCommandTests
    {
        private readonly UpdateClientByIdCommand _updateClientByIdCommand;
        private readonly Mock<IApiDbContext> _context;

        public UpdateClientByIdCommandTests()
        {
            SQLitePCL.Batteries.Init(); 
            var db = new InMemoryDatabase();
            _updateClientByIdCommand = new UpdateClientByIdCommand(new ClientDto { Name = "Name", Surname = "Surname" });
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Fact]
        public async Task UpdateClientByIdCommand_Should_Return_Record()
        {
            // Arrange
            var request = new UpdateClientByIdCommand.UpdateClientByIdCommandHandler(_context.Object);

            // Act
            await request.Handle(_updateClientByIdCommand, CancellationToken.None);

            // Assert
            _context.Verify(x => x.CreateConnection(), Times.Once());
        }
    }
}
