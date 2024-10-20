using Template.Domain.Interface;
using Template.Domain.LogsAggregate.Enum;

namespace Template.Services.Services
{
    public class LogServiceFactory
    {
        private readonly IEnumerable<ILogServices> _logServices;
        private int _currentLogTypeIndex = 0;

        public LogServiceFactory(IEnumerable<ILogServices> logServices)
        {
            _logServices = logServices;

            // Configurar LogsSaveApi como el servicio predeterminado
            var defaultService = _logServices.FirstOrDefault(s => s.UseLogsType == LogsType.SaveApi);
            if (defaultService != null)
            {
                _currentLogTypeIndex = _logServices.ToList().IndexOf(defaultService);
            }
        }

        public ILogServices GetCurrentLogService()
        {
            return _logServices.ElementAt(_currentLogTypeIndex);
        }

        public void SetLogService(LogsType logsType)
        {
            var service = _logServices.FirstOrDefault(s => s.UseLogsType == logsType);
            if (service != null)
            {
                _currentLogTypeIndex = _logServices.ToList().IndexOf(service);
            }
        }
    }
}
