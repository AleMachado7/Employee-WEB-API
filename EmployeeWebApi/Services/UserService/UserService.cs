using EmployeeWebApi.DataContext;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public async Task<ServiceResponse<UserModel>> CreateAsync(UserParams createParams)
        {
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                var user = UserModel.Create(createParams);

                if (user == null)
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
            throw new NotImplementedException();
        }
    }
}
