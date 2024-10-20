using Template.Domain.LogsAggregate.Enum;
using Template.Domain.UserAggregate.Enum;

namespace Template.Services.Command.UserCommand
{
    public class ChangeServicesCommand
    {
        public required LogsType LogsType { get; set; }
        public required EncrypType EncrypType { get; set; }
    }
}
