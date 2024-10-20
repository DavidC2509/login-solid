using ControllerCqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Services.Command.UserCommand;
using Template.Services.Services;

namespace Template.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ServiceBaseController
    {
        private readonly LogServiceFactory _logServiceFactory;
        private readonly PasswordServiceFactory _passwordServiceFactory;


        public UserController(IMediator mediator, LogServiceFactory logServiceFactory, PasswordServiceFactory passwordServiceFactory) : base(mediator)
        {
            _logServiceFactory = logServiceFactory;
            _passwordServiceFactory = passwordServiceFactory;
        }

        ///<summary>
        ///Crear Usuario
        ///</summary>
        [HttpPost("store")]
        public async Task<ActionResult<bool>> StoreUser([FromBody] StoreUserCommand command, CancellationToken cancellationToken)
        {
            // Obtener el servicio de log según la rotación actual
            var _logsServices = _logServiceFactory.GetCurrentLogService();

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
            // Obtener el servicio de log según la rotación actual
            var _logsServices = _logServiceFactory.GetCurrentLogService();

            await _logsServices.SaveLogsService("LoginUser", $"Logs Login user username;{command.Name}", cancellationToken);
            var result = await SendRequest(command);

            return result;
        }

        ///<summary>
        ///Cambiar el tipo de logs manualmente
        ///</summary>
        [HttpPost("change-log-password-type")]
        public ActionResult ChangeLogType([FromBody] ChangeServicesCommand command)
        {
            _logServiceFactory.SetLogService(command.LogsType);
            _passwordServiceFactory.SetPasswordServices(command.EncrypType);

            return Ok($"Log type changed to: {command.LogsType} and Password Type to :{command.EncrypType} ");
        }
    }
}
