using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dapper_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private IMediator _mediator;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
#pragma warning disable CS8601 // Posible asignación de referencia nula
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8601 // Posible asignación de referencia nula
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
    }
}
