using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmployeeWebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
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

                serviceResponse.Data = new UserResult(user);
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
        public async Task<ServiceResponse<UserResult>> GetHttpContextUser()
        {
            var serviceResponse = new ServiceResponse<UserResult>();

            try
            {
                Claim claim = _httpContext.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id");

                if (claim != null)
                {
                    string id = claim.Value;
                    var user = await GetUserByIdAsync(Guid.Parse(id));

                    if (user is null)
                    {
                        serviceResponse.Data = null;
                        serviceResponse.Message = "Can't find user";
                        serviceResponse.Success = false;

                        return serviceResponse;
                    }

                    serviceResponse.Data = new UserResult(user);
                    serviceResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserResult>>> GetUsersAsync()
        {
            var serviceResponse = new ServiceResponse<List<UserResult>>();
            try
            {
                var users = await _context.Users.ToListAsync();
                var result = new List<UserResult>();

                foreach (var user in users)
                {
                    result.Add(new UserResult(user));
                }

                serviceResponse.Data = result;
                serviceResponse.Success = true;

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "No data was found.";
                }
            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}