using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<UserResult>> CreateAsync(UserParams createParams);
        Task<ServiceResponse<UserResult>> LoginAsync(LoginParams loginParams);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> GetUserByIdAsync(Guid id);        
    }
}
