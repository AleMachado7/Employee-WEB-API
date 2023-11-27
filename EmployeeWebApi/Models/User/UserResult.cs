namespace EmployeeWebApi.Models.User
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public UserResult(Guid Id, string email)
        {
            this.Id = Id;
            this.Email = email;
        }
    }
}
