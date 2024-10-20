namespace Template.Domain.Interface
{
    public interface ILogServices
    {
        Task<bool> SaveLogsService(string title, string messageLogs, CancellationToken cancellationToken);
    }
}
