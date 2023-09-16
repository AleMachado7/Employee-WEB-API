using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models.User
{
    public class UserParams
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
