using MediatR;

namespace Template.Services.Command.UserCommand
{
    public class LoginUserCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
