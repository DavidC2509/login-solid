using Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Models;
using Template.Services.Query.ExampleQuery;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/example")]
    [ApiController]
    public class ExampleController : ServiceBaseController
    {
        public ExampleController(IMediator mediator) : base(mediator) { }

        ///<summary>
        ///Listado Producto
        ///</summary>
        [HttpGet("list")]
        public Task<ActionResult<IEnumerable<ExampleModels>>> ListProduct() => SendRequest(new ListExampleQuery());
    }
}
