using System.Security.Cryptography;

namespace EmployeeWebApi.Cryptographys
{
    public class Cryptography
    {
        public static void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool ValidatePassword(string password, byte[] pwdHash, byte[] pwdSalt)
        {
            using (var hmac = new HMACSHA512(pwdSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(pwdHash);
            }
        }
    }
}
