using dapper_api.DTOs;
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
            var clients = await Mediator.Send(new GetAllClientsQuery());

            if (!clients.Any())
            {
                return NoContent();
            }

            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await Mediator.Send(new GetClientByIdQuery(id));
            
            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] ClientDTO client)
        {
            var existentClient = await Mediator.Send(new GetClientByIdQuery(client.Id));
            
            if (!(existentClient is null))
            {
                return BadRequest("Client already exists.");
            }

            await Mediator.Send(new CreateClientCommand(client));

            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<ActionResult<Client>> UpdateClientById([FromBody]ClientDTO client)
        {
            var existentClient = await Mediator.Send(new GetClientByIdQuery(client.Id));

            if (existentClient is null)
            {
                return NotFound();
            }

            if(client.Equals(existentClient))
            {
                return BadRequest("Client already exists.");
            }

            await Mediator.Send(new UpdateClientByIdCommand(client));

            return Ok();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientById(int id)
        {
            var existentClient = await Mediator.Send(new GetClientByIdQuery(id));

            if (existentClient is null)
            {
                return NotFound();
            }

            await Mediator.Send(new DeleteClientByIdCommand(id));

            return Ok();
        }
    }
}
