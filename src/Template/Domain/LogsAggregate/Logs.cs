using Core.Cqrs.Domain;
using Core.Cqrs.Domain.Domain;

namespace Template.Domain.LogsAggregate
{
    public class Logs : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Message { get; set; }

        private Logs()
        {
            Title = string.Empty;
            Message = string.Empty;

        }

        internal Logs(string title, string message) : this()
        {
            Title = title;
            Message = message;

        }

        public static Logs CreateLogs(string title, string message)
       => new(title, message);
    }
}
