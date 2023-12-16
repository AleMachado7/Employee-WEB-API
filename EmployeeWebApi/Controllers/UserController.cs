using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using EmployeeWebApi.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<UserResult>>> CreateAsync(UserParams createParams)
        {
            return Ok(await this._userService.CreateAsync(createParams));
        }

        [HttpGet("currentUser")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<UserResult>>> getCurrentUser()
        {
            return Ok(await this._userService.GetHttpContextUser());
        }
    }
}
