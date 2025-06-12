using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dapper_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController(ISender mediator) : ControllerBase
    {
        protected ISender Mediator => mediator ??  throw new ArgumentNullException(nameof(mediator));
    }
}
