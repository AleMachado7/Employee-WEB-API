namespace EmployeeWebApi.Models.User
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UserResult(Guid Id, string email, string token)
        {
            this.Id = Id;
            this.Email = email;
            this.Token = token;
        }
    }
}
