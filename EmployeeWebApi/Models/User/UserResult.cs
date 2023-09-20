namespace EmployeeWebApi.Models.User
{
    public class UserResult
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public UserResult(string email, string token)
        {
            this.Email = email;
            this.Token = token;
        }
    }
}
