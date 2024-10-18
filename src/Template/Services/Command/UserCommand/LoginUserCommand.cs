using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Command.UserCommand
{
    public class LoginUserCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
