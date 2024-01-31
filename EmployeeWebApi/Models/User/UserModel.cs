using System.ComponentModel.DataAnnotations;
using EmployeeWebApi.Cryptographys;

namespace EmployeeWebApi.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Key]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; } = true;
        public static UserModel Create(UserParams createParams)
        {
            var model = new UserModel
            {
                Email = createParams.Email
            };

            Cryptography.GeneratePasswordHash(createParams.Password, out byte[] userPwdHash, out byte[] userPwdSalt);

            model.PasswordHash = userPwdHash;
            model.PasswordSalt = userPwdSalt;

            return model;
        }
    }
}
