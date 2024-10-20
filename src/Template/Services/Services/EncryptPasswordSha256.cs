using System.Security.Cryptography;
using System.Text;
using Template.Domain.Interface;
using Template.Domain.UserAggregate.Enum;

namespace Template.Services.Services
{
    public class EncryptPasswordSha256 : IEncryptPassword
    {
        public EncrypType UseEncrypType => EncrypType.EncryptHas256;

        public string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}