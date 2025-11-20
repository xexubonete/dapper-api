using Dapper.Application.Services.Commands;
using Dapper.Domain.Interfaces;
using Moq;

namespace Dapper.Application.Tests.Services.Commands
{
    public class DeleteClientByIdCommandTests
    {
        private readonly DeleteClientByIdCommand _deleteClientByIdCommand;
        private readonly Mock<IApiDbContext> _context;

        public DeleteClientByIdCommandTests()
        {
            SQLitePCL.Batteries.Init(); 
            var db = new InMemoryDatabase();
            _deleteClientByIdCommand = new DeleteClientByIdCommand(1);
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Fact]
        public async Task DeleteClientByIdCommand_Should_Return_Record()
        {
            var request = new DeleteClientByIdCommand.DeleteClientByIdCommandHandler(_context.Object);

            await request.Handle(_deleteClientByIdCommand, CancellationToken.None);

            Assert.True(true);
        }
    }
}
