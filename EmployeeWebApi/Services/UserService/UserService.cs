using EmployeeWebApi.Cryptographys;
using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using EmployeeWebApi.Services.TokenService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EmployeeWebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public UserService(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ServiceResponse<UserResult>> CreateAsync([FromBody] UserParams createParams)
        {
            var serviceResponse = new ServiceResponse<UserResult>();

            try
            {
                var userExists = await GetUserByEmailAsync(createParams.Email);

                if (userExists is not null)
                {
                    serviceResponse.Message = "User already exists";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                var user = UserModel.Create(createParams);

                if (user is null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User is null, please check the Model information.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = new UserResult(user.Id, user.Email, user.Token);
                serviceResponse.Success = true;
                serviceResponse.Message = "User created!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserResult>> LoginAsync([FromBody] LoginParams loginParams) 
        {
            var serviceResponse = new ServiceResponse<UserResult>();
            try
            {
                var user = await GetUserByEmailAsync(loginParams.Email);

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

                user.Token = _tokenService.GenerateUserToken(user); ;

                serviceResponse.Data = new UserResult(user.Id, user.Email, user.Token);
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

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(Guid Id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}