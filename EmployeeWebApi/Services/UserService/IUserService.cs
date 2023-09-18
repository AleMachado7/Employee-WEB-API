﻿using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.ServiceResponse;
using EmployeeWebApi.Models.User;

namespace EmployeeWebApi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<UserResult>> CreateAsync(UserParams createParams);
        Task<ServiceResponse<UserResult>> LoginAsync(string email, string password);
        Task<UserModel> GetUserByEmailAsync(string email);
    }
}
