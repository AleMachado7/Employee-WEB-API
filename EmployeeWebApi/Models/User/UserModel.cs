using EmployeeWebApi.Models.Token;
using EmployeeWebApi.Models.Criptographys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public TokenModel Token { get; set; } = new TokenModel();

        public static UserModel Create(UserParams createParams)
        {
            var model = new UserModel();

            model.Email = createParams.Email;
            Cryptography.CreateUserPasswordHash(createParams.Password, model);

            return model;
        }
    }
}
