using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            var model = new UserModel();

            model.Email = createParams.Email;

            Cryptography.GeneratePasswordHash(createParams.Password, out byte[] userPwdHash, out byte[] userPwdSalt);

            model.PasswordHash = userPwdHash;
            model.PasswordSalt = userPwdSalt;

            return model;
        }
    }
}
