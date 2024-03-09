using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dapper_api.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<string> GetAllClients()
        {
            return new string[] { "value1", "value2" };
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
