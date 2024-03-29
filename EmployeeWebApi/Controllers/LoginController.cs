﻿using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using EmployeeWebApi.Services.LoginService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<UserResult>>> LoginAsync(LoginParams loginParams)
        {
            return this.Ok(await _loginService.LoginAsync(loginParams));
        }
    }
}
