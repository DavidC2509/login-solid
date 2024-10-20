﻿using Core.Cqrs.Domain.Repository;
using Template.Domain.Interface;
using Template.Domain.LogsAggregate;
using Template.Domain.LogsAggregate.Enum;

namespace Template.Services.Services
{
    public class LogsSaveDatabase : ILogServices
    {
        public LogsType UseLogsType => LogsType.SaveDatabase;

        private readonly IRepository<Logs> _repository;

        public LogsSaveDatabase(IRepository<Logs> repository)
        {
            _repository = repository;
        }

        public async Task<bool> SaveLogsService(string title, string messageLogs, CancellationToken cancellationToken = default)
        {
            try
            {
                var logs = Logs.CreateLogs(title, messageLogs);
                _repository.Add(logs);
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
