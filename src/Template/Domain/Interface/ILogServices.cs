using Template.Domain.LogsAggregate.Enum;

namespace Template.Domain.Interface
{
    public interface ILogServices
    {
        LogsType UseLogsType { get; }

        Task<bool> SaveLogsService(string title, string messageLogs, CancellationToken cancellationToken);
    }
}
