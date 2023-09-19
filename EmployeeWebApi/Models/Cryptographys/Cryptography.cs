using EmployeeWebApi.Models.User;
using System.Security.Cryptography;

namespace EmployeeWebApi.Models.Criptographys
{
    public class Cryptography
    {
        public static void CreateUserPasswordHash(string password, UserModel user)
        {
            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
