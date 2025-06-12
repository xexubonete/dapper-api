using Dapper.Application.Services.Queries;
using Dapper.Domain.Interfaces;
using Moq;

namespace dapper_api_test.Services.Queries
{
    public class GetAllClientsQueryTest
    {
        private GetAllClientsQuery getAllClientsQuery;
        private Mock<IApiDbContext> _context;
        private InMemoryDatabase db;

        public GetAllClientsQueryTest()
        {
            db = new InMemoryDatabase();
            getAllClientsQuery = new GetAllClientsQuery();
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Test]
        public async Task GetAllClientsQuery_Should_Return_Records()
        {
            var request =  new GetAllClientsQuery.GetAllClientsQueryHandler(_context.Object);
            var result = await request.Handle(getAllClientsQuery, CancellationToken.None);

            Assert.That(result is not null);
        }
    }
}
