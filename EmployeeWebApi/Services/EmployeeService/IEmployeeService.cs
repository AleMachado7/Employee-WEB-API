using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;

namespace EmployeeWebApi.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<EmployeeResponse>> GetEmployeesAsync(int pageNumber);
        Task<ServiceResponse<EmployeeModel>> GetEmployeeByIdAsync(Guid Id);
        Task<ServiceResponse<EmployeeModel>> CreateEmployeeAsync(EmployeeParams createParams);
        Task<ServiceResponse<EmployeeModel>> UpdateEmployeeAsync(Guid id, EmployeeParams updateParams);
        Task<ServiceResponse<EmployeeModel>> DeleteEmployeeAsync(Guid id);
        Task<ServiceResponse<EmployeeModel>> InactivateEmployeeAsync(Guid id);
    }
}
