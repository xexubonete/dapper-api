using Dapper.Domain.Interfaces;
using Dapper.Application.Services.Commands;
using Dapper.Domain.Dtos;
using Moq;

namespace Dapper.Application.Tests.Services.Commands
{
    public class CreateClientCommandTests
    {
        private readonly CreateClientCommand _createClientCommand;
        private readonly Mock<IApiDbContext> _context;

        public CreateClientCommandTests()
        {
            SQLitePCL.Batteries.Init(); 
            var db = new InMemoryDatabase();
            _createClientCommand = new CreateClientCommand(new ClientDto { Name = "Name", Surname = "Surname" });
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Fact]
        public async Task CreateClientCommand_Should_Return_Record()
        {
            var request = new CreateClientCommand.CreateClientCommandHandler(_context.Object);
            await request.Handle(_createClientCommand, CancellationToken.None);
            
            _context.Verify(x => x.CreateConnection(), Times.Once());
        }
    }
}
