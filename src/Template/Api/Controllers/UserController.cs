using ControllerCqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Domain.Interface;
using Template.Services.Command.UserCommand;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ServiceBaseController
    {
        private readonly ILogServices _logsServices;


        public UserController(IMediator mediator, ILogServices logsServices) : base(mediator)
        {
            _logsServices = logsServices;
        }

        ///<summary>
        ///Crear Usuario
        ///</summary>
        [HttpPost("store")]
        public async Task<ActionResult<bool>> StoreUser([FromBody] StoreUserCommand command)
        {
            _logsServices.SaveLogsService($"Register User from data username {command.Name}");
            var result = await SendRequest(command);

            return result;
        }

        ///<summary>
        ///Login
        ///</summary>
        [HttpPost("login")]
        public async Task<ActionResult<bool>> LoginUser([FromBody] LoginUserCommand command)
        {
            _logsServices.SaveLogsService($"Logs Login user username;{command.Name}");
            var result = await SendRequest(command);

            return result;
        }
    }
}
