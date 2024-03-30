using dapper_api.Models;
using dapper_api.Services.Queries;

namespace dapper_api_test.Services.Queries
{
    public class GetAllClientsQueryTest
    {
        private GetAllClientsQuery getAllClientsQuery;
        private ApiDbContext _context;

        public GetAllClientsQueryTest()
        {
            getAllClientsQuery = new GetAllClientsQuery();
            _context = new ApiDbContext();
        }

        [Test]
        public async Task GetAllClientsQuery_Should_Return_Records()
        {
            var handler =  new GetAllClientsQuery.GetAllClientsQueryHandler(_context);
            var result = await handler.Handle(getAllClientsQuery, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
        }
    }
}
