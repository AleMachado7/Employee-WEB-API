using Newtonsoft.Json;

namespace EmployeeWebApi.Services.LoginService
{
    public class LoginParams
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
