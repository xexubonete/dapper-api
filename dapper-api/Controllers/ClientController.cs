using dapper_api.Entities;
using dapper_api.Services.Commands;
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
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery(id)));
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] Client client)
        {
            return Ok(await Mediator.Send(new CreateClientCommand(client)));
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<ActionResult<Client>> UpdateClientById([FromBody]Client client)
        {
            return Ok(await Mediator.Send(new UpdateClientByIdCommand(client)));
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientById(int id)
        {
            await Mediator.Send(new DeleteClientByIdCommand(id));
            return Ok();
        }
    }
}
