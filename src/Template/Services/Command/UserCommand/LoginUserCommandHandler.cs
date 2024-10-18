using AutoMapper;
using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interface;
using Template.Domain.UserAggregate;
using Template.Domain.UserAggregate.Spec;

namespace Template.Services.Command.UserCommand
{
    public class LoginUserCommandHandler : BaseCommandHandler<IRepository<User>, LoginUserCommand, bool>
    {
        private readonly IEncryptPassword _encrypPassword;

        public LoginUserCommandHandler(IRepository<User> repository, IEncryptPassword encrypPassword) : base(repository)
        {
            _encrypPassword = encrypPassword;
        }

        public async override Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserByNameSpec(request.Name);
            var user = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            if (user == null) { return false; }

            var password = _encrypPassword.EncryptPassword(request.Password);

            return password == user.Password;
        }
    }
}
