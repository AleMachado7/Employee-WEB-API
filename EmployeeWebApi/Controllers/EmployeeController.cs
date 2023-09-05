using EmployeeWebApi.Models;
using EmployeeWebApi.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployeeAsync(EmployeeModel employee)
        {
            return Ok(await _employeeService.CreateEmployeeAsync(employee));
        }
    }
}
