﻿using Core.CommandAndQueryHandler;
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
    public class StoreUserCommandHandler : BaseCommandHandler<IRepository<User>, StoreUserCommand, bool>
    {
        private readonly IEncryptPassword _encrypPassword;

        public StoreUserCommandHandler(IRepository<User> repository, IEncryptPassword encrypPassword) : base(repository)
        {
            _encrypPassword = encrypPassword;
        }

        public async override Task<bool> Handle(StoreUserCommand request, CancellationToken cancellationToken)
        {
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