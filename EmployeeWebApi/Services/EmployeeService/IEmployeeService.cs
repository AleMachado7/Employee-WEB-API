using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;

namespace EmployeeWebApi.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployeesAsync();
        Task<ServiceResponse<EmployeeModel>> GetEmployeeByIdAsync(Guid Id);
        Task<ServiceResponse<EmployeeModel>> CreateEmployeeAsync(EmployeeParams createParams);
        Task<ServiceResponse<EmployeeModel>> UpdateEmployeeAsync(EmployeeModel employee);
        Task<ServiceResponse<EmployeeModel>> DeleteEmployeeAsync(Guid id);
        Task<ServiceResponse<EmployeeModel>> InactivateEmployeeAsync(Guid id);
    }
}
