namespace EmployeeWebApi.Models.Token
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
