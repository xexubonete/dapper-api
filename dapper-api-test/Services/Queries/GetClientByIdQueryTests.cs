using dapper_api.Interfaces;
using dapper_api.Services.Queries;
using Moq;

namespace dapper_api_test.Services.Queries
{
    public class GetClientByIdQueryTests
    {
        private GetClientByIdQuery getClientByIdQuery;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;

        public GetClientByIdQueryTests()
        {
            db = new InMemoryDatabase();
            int id = 1;
            getClientByIdQuery = new GetClientByIdQuery(id);
            _context = new Mock<IApiDbContext>();
            db.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task GetClientByIdQuery_Should_Return_Record()
        {
            var request = new GetClientByIdQuery.GetClientByIdQueryHandler(_context.Object);
            var result = await request.Handle(getClientByIdQuery, CancellationToken.None);

            Assert.That(result != null);
        }
    }
}
