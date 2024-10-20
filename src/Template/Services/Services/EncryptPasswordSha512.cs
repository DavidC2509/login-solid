using System.Security.Cryptography;
using System.Text;
using Template.Domain.Interface;

namespace Template.Services.Services
{
    public class EncryptPasswordSha512 : IEncryptPassword
    {
        public string EncryptPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
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