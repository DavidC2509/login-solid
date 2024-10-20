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
        public async Task<ActionResult<bool>> StoreUser([FromBody] StoreUserCommand command, CancellationToken cancellationToken)
        {
            await _logsServices.SaveLogsService("RegisterUser", $"Register User from data username {command.Name}", cancellationToken);
            var result = await SendRequest(command);

            return result;
        }

        ///<summary>
        ///Login
        ///</summary>
        [HttpPost("login")]
        public async Task<ActionResult<bool>> LoginUser([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
        {
            await _logsServices.SaveLogsService("LoginUser", $"Logs Login user username;{command.Name}", cancellationToken);
            var result = await SendRequest(command);

            return result;
        }
    }
}
