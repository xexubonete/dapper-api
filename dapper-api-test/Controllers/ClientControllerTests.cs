using dapper_api.Controllers;
using dapper_api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_api_test.Controllers
{
    public class ClientControllerTests
    {
        private ClientController clientController;
        public ClientControllerTests()
        {
            Client client = new Client {

                Id = 1,
                Name = "test",
                Surname = "test"

            };

            clientController = new ClientController();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_Clients_By_Id_Should_Return_Records()
        {
            int id = 1;
            var records = await clientController.GetClientById(id);

            Assert.True(records is OkObjectResult);
        }
    }
}
