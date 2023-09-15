using EmployeeWebApi.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    public class UserController : Controller
    {
        [Route("api/sign-in")]
        [ApiController]
        public class SignInController : Controller
        {
            private readonly IUserService _userService;

            public SignInController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost("")]
            [AllowAnonymous]
            public async Task<IActionResult> SignInAsync()
            {

                return this.Ok();
            }
        }
    }
}
