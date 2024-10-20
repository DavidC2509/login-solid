
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.UserAggregate;
using Template.Domain.UserAggregate.Spec;
using Template.Services.Services;

namespace Template.Services.Command.UserCommand
{
    public class LoginUserCommandHandler : BaseCommandHandler<IRepository<User>, LoginUserCommand, bool>
    {
        private readonly PasswordServiceFactory _passwordServiceFactory;


        public LoginUserCommandHandler(IRepository<User> repository, PasswordServiceFactory passwordServiceFactory) : base(repository)
        {
            _passwordServiceFactory = passwordServiceFactory;
        }

        public async override Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Obtener el servicio de log según la rotación actual
            var _encrypPassword = _passwordServiceFactory.GetCurrentLogService();

            var spec = new UserByNameSpec(request.Name);
            var user = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            if (user == null) { return false; }

            var password = _encrypPassword.EncryptPassword(request.Password);

            return password == user.Password;
        }
    }
}
