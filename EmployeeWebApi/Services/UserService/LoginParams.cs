using Newtonsoft.Json;

namespace EmployeeWebApi.Services.UserService
{
    public class LoginParams
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
