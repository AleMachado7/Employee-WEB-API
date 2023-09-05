using EmployeeWebApi.Models;

namespace EmployeeWebApi.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployeesAsync();
        Task<ServiceResponse<EmployeeModel>> GetEmployeeByIdAsync(Guid Id);
        Task<ServiceResponse<EmployeeModel>> CreateEmployeeAsync(EmployeeModel employee);
        Task<ServiceResponse<EmployeeModel>> UpdateEmployeeAsync(EmployeeModel employee);
        Task<ServiceResponse<EmployeeModel>> DeleteEmployeeAsync(Guid id);
        Task<ServiceResponse<EmployeeModel>> InactivateEmployeeAsync(Guid id);
    }
}
