namespace EmployeeWebApi.Models.Login
{
    public class LoginResult
    {
        public string Token { get; set; }

        public LoginResult(string token)
        {
            this.Token = token;
        }
    }
}
