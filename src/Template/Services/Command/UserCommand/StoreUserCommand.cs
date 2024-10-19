using MediatR;

namespace Template.Services.Command.UserCommand
{
    public class StoreUserCommand : IRequest<bool>
    {
        public required string Name { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
