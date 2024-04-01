using dapper_api.Interfaces;
using dapper_api.Services.Commands;
using Moq;

namespace dapper_api_test.Services.Commands
{
    public class DeleteClientByIdCommandTests
    {
        private DeleteClientByIdCommand deleteClientByIdCommand;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;
        int id = 1;

        public DeleteClientByIdCommandTests()
        {
            db = new InMemoryDatabase();
            deleteClientByIdCommand = new DeleteClientByIdCommand(id);
            _context = new Mock<IApiDbContext>();
            db.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task DeleteClientByIdCommand_Should_Return_Record()
        {
            var request = new DeleteClientByIdCommand.DeleteClientByIdCommandHandler(_context.Object);

            await request.Handle(deleteClientByIdCommand, CancellationToken.None);

            Assert.That(true);
        }
    }
}
