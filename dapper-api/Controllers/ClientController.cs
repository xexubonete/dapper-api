using dapper_api.Entities;
using dapper_api.Services.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dapper_api.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/<ClientController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var result = await Mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string GetClientById(int id)
        {
            return "value";
        }

        // POST api/<ClientController>
        [HttpPost]
        public void CreateClient([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void UpdateClientById(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void DeleteClientById(int id)
        {
        }
    }
}
