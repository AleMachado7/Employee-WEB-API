using EmployeeWebApi.Models.Login;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.LoginService
{
    public interface ILoginService
    {
        Task<ServiceResponse<LoginResult>> LoginAsync(LoginParams loginParams);
    }
}
