using Template.Domain.Interface;
using Template.Domain.UserAggregate.Enum;

namespace Template.Services.Services
{
    public class PasswordServiceFactory
    {
        private readonly IEnumerable<IEncryptPassword> _encrypServices;
        private int _currentLogTypeIndex = 0;

        public PasswordServiceFactory(IEnumerable<IEncryptPassword> logServices)
        {
            _encrypServices = logServices;

            // Configurar LogsSaveApi como el servicio predeterminado
            var defaultService = _encrypServices.FirstOrDefault(s => s.UseEncrypType == EncrypType.EncryptHas512);
            if (defaultService != null)
            {
                _currentLogTypeIndex = _encrypServices.ToList().IndexOf(defaultService);
            }
        }

        public IEncryptPassword GetCurrentLogService()
        {
            return _encrypServices.ElementAt(_currentLogTypeIndex);
        }

        public void SetPasswordServices(EncrypType encrypType)
        {
            var service = _encrypServices.FirstOrDefault(s => s.UseEncrypType == encrypType);
            if (service != null)
            {
                _currentLogTypeIndex = _encrypServices.ToList().IndexOf(service);
            }
        }
    }
}
