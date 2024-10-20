
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.UserAggregate;
using Template.Services.Services;

namespace Template.Services.Command.UserCommand
{
    public class StoreUserCommandHandler : BaseCommandHandler<IRepository<User>, StoreUserCommand, bool>
    {
        private readonly PasswordServiceFactory _passwordServiceFactory;

        public StoreUserCommandHandler(IRepository<User> repository, PasswordServiceFactory passwordServiceFactory) : base(repository)
        {
            _passwordServiceFactory = passwordServiceFactory;
        }

        public async override Task<bool> Handle(StoreUserCommand request, CancellationToken cancellationToken)
        {
            // Obtener el servicio de log según la rotación actual
            var _encrypPassword = _passwordServiceFactory.GetCurrentLogService();

            try
            {
                var password = _encrypPassword.EncryptPassword(request.Password);
                var userCreate = User.CreateUser(request.Name, password, request.Email, request.Phone);
                _repository.Add(userCreate);
                await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}