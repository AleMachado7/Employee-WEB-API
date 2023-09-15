using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<UserModel>> CreateAsync(UserParams createParams);
        Task<ServiceResponse<UserModel>> LoginAsync(string email, string password);
    }
}
