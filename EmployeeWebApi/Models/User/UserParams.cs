using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models.User
{
    public class UserParams
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
