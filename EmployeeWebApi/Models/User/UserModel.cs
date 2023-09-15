using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeWebApi.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Active { get; set; } = true;
        [NotMapped]
        public string Token { get; set; }

        public static UserModel Create(UserParams createParams)
        {
            var model = new UserModel();

            model.Email = createParams.Email;
            model.Password = createParams.Password;

            return model;
        }
    }
}
