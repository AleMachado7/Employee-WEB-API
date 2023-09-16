using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployeesAsync()
        {
            return Ok(await _employeeService.GetEmployeesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeByIdAsync(Guid id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployeeAsync(EmployeeParams createParams)
        {
            return Ok(await _employeeService.CreateEmployeeAsync(createParams));
        }

        [HttpPut("inactivateEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> InactivateEmployeeAsync(Guid id)
        {
            return Ok(await _employeeService.InactivateEmployeeAsync(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> UpdateEmployeeAsync(EmployeeModel employeeToUpdate)
        {
            return Ok(await _employeeService.UpdateEmployeeAsync(employeeToUpdate));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> DeleteEmployeeAsync(Guid id)
        {
            return Ok(await _employeeService.DeleteEmployeeAsync(id));
        }
    }
}
