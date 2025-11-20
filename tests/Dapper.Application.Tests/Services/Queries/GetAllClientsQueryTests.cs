using Dapper.Application.Services.Queries;
using Dapper.Domain.Interfaces;
using Moq;

namespace Dapper.Application.Tests.Services.Queries
{
    public class GetAllClientsQueryTest
    {
        private readonly GetAllClientsQuery _getAllClientsQuery;
        private readonly Mock<IApiDbContext> _context;

        public GetAllClientsQueryTest()
        {
            SQLitePCL.Batteries.Init(); 
            var db = new InMemoryDatabase();
            _getAllClientsQuery = new GetAllClientsQuery();
            _context = new Mock<IApiDbContext>();
            InMemoryDatabase.CreateDatabaseTest(db);
            _context.Setup(x => x.CreateConnection()).Returns(db.OpenConnection());
        }

        [Fact]
        public async Task GetAllClientsQuery_Should_Return_Records()
        {
            var request =  new GetAllClientsQuery.GetAllClientsQueryHandler(_context.Object);
            var result = await request.Handle(_getAllClientsQuery, CancellationToken.None);

            Assert.True(result is not null);
        }
    }
}
