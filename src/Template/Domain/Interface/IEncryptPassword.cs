using Template.Domain.UserAggregate.Enum;

namespace Template.Domain.Interface
{
    public interface IEncryptPassword
    {
        EncrypType UseEncrypType { get; }

        string EncryptPassword(string password);

    }
}
