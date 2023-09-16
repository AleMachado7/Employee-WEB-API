using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<UserModel>> CreateAsync(UserParams createParams)
        {
            var serviceResponse = new ServiceResponse<UserModel>();

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

                serviceResponse.Data = user;
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

        public async Task<ServiceResponse<UserModel>> LoginAsync(string email, string password)
        {
            var serviceResponse = new ServiceResponse<UserModel>();
            try
            {
                var user = await GetUserByEmailAsync(email);

                if (user is null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User doesn't exist";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                serviceResponse.Data = user;
                serviceResponse.Success = true;

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
    }
}