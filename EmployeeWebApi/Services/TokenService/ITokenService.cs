using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateUserToken(UserModel user);
    }
}
