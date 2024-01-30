using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<EmployeeModel>> CreateEmployeeAsync(EmployeeParams createParams)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = EmployeeModel.Create(createParams);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee is null, please check the Model information.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Success = true;
                serviceResponse.Message = "Employee created!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> DeleteEmployeeAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Success = true;
                serviceResponse.Message = "Employee deleted!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeByIdAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = true;
                    return serviceResponse;
                }

                serviceResponse.Message = "Employee found!";
                serviceResponse.Data = employee;
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeResponse>> GetEmployeesAsync(int pageNumber)
        {
            var serviceResponse = new ServiceResponse<EmployeeResponse>();

            try
            {
                var pageSize = 5f;
                var pageCount = Math.Ceiling(this._context.Employees.Count() / pageSize);

                var employees = await _context.Employees
                    .Skip((pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize)
                    .ToListAsync();

                serviceResponse.Data = new EmployeeResponse
                {
                    Employees = employees,
                    CurrentPage = pageNumber,
                    TotalPages = (int) pageCount
                };

                serviceResponse.Success = true;

                if (serviceResponse.Data.Employees.Count == 0)
                {
                    serviceResponse.Message = "No data was found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> InactivateEmployeeAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                employee.Active = !employee.Active;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Success = true;
                serviceResponse.Message = employee.Active ? "Employee Activated!" : "Employee Inactivated!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> UpdateEmployeeAsync(Guid id, EmployeeParams updateParams)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                employee.Update(updateParams);

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Success = true;
                serviceResponse.Message = "Employee updated!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
