using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Services.EmployeeService;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("page/{pageNumber}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployeesAsync([FromRoute] int pageNumber)
        {
            return Ok(await _employeeService.GetEmployeesAsync(pageNumber));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployeeAsync([FromBody] EmployeeParams createParams)
        {
            return Ok(await _employeeService.CreateEmployeeAsync(createParams));
        }

        [HttpPut("inactivate/{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> InactivateEmployeeAsync([FromRoute] Guid id)
        {
            return Ok(await _employeeService.InactivateEmployeeAsync(id));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] EmployeeParams updateParams)
        {
            return Ok(await _employeeService.UpdateEmployeeAsync(id, updateParams));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> DeleteEmployeeAsync([FromRoute] Guid id)
        {
            return Ok(await _employeeService.DeleteEmployeeAsync(id));
        }
    }
}
