using EmployeeWebApi.Cryptographys;
using EmployeeWebApi.Models.Login;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using EmployeeWebApi.Services.TokenService;
using EmployeeWebApi.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public LoginService(ITokenService tokenService, IUserService userService)
        {
            this._tokenService = tokenService;
            this._userService = userService;
        }

        public async Task<ServiceResponse<LoginResult>> LoginAsync([FromBody] LoginParams loginParams)
        {
            var serviceResponse = new ServiceResponse<LoginResult>();
            try
            {
                var user = await _userService.GetUserByEmailAsync(loginParams.Email);

                if (user is null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User doesn't exist";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                var passwordCorret = Cryptography.ValidatePassword(loginParams.Password, user.PasswordHash, user.PasswordSalt);

                if (!passwordCorret)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Wrong password!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                var token = _tokenService.GenerateUserToken(user); ;

                serviceResponse.Data = new LoginResult(token);
                serviceResponse.Success = true;
                serviceResponse.Message = "Login successful";

                return serviceResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                return serviceResponse;
            }

        }
    }
}
