using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models;
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

        public async Task<ServiceResponse<EmployeeModel>> CreateEmployeeAsync(EmployeeModel employee)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
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
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeByIdAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = _context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

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

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployeesAsync()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Data = await _context.Employee.ToListAsync();
                serviceResponse.Success = true;

                if (serviceResponse.Data.Count == 0)
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
                var employee = _context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                employee.Active = false;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();

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

        public async Task<ServiceResponse<EmployeeModel>> UpdateEmployeeAsync(EmployeeModel employeeToUpdate)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                var employee = _context.Employee.AsNoTracking().FirstOrDefault(x => x.Id == employeeToUpdate.Id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employee.Update(employeeToUpdate);
                await _context.SaveChangesAsync();

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
    }
}
