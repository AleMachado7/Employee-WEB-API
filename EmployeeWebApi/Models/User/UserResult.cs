using EmployeeWebApi.Models.Token;

namespace EmployeeWebApi.Models.User
{
    public class UserResult
    {
        public string Email { get; set; }
        public TokenModel Token { get; set; } = new TokenModel();

        public UserResult(string email, TokenModel token)
        {
            this.Email = email;
            this.Token = token;
        }
    }
}
