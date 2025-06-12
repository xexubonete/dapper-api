using Dapper.Application.Services.Commands;
using Dapper.Application.Services.Queries;
using Dapper.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/<ClientController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = await this.Mediator.Send(new GetAllClientsQuery());

            if (!clients.Any())
            {
                return NoContent();
            }

            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            ClientDto? client = await this.Mediator.Send(new GetClientByIdQuery(id));
            
            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient([FromBody] ClientDto client)
        {
            ClientDto? existentClient = await this.Mediator.Send(new GetClientByIdQuery(client.Id));
            
            if (!(existentClient is null))
            {
                return BadRequest("Client already exists.");
            }

            await this.Mediator.Send(new CreateClientCommand(client));

            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<ActionResult<ClientDto>> UpdateClientById([FromBody]ClientDto client)
        {
            ClientDto? existentClient = await this.Mediator.Send(new GetClientByIdQuery(client.Id));

            if(client.Equals(existentClient))
            {
                return BadRequest("Client already exists.");
            }

            await this.Mediator.Send(new UpdateClientByIdCommand(client));

            return Ok();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientById(int id)
        {
            ClientDto? existentClient = await this.Mediator.Send(new GetClientByIdQuery(id));

            if (existentClient is null)
            {
                return NotFound();
            }

            await this.Mediator.Send(new DeleteClientByIdCommand(id));

            return Ok();
        }
    }
}
