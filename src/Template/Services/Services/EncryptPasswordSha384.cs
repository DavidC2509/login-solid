using System.Security.Cryptography;
using System.Text;
using Template.Domain.Interface;

namespace Template.Services.Services
{
    public class EncryptPasswordSha384 : IEncryptPassword
    {
        public string EncryptPassword(string password)
        {
            using (SHA384 sha384 = SHA384.Create())
            {
                byte[] bytes = sha384.ComputeHash(Encoding.UTF8.GetBytes(password));
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