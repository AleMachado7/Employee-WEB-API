﻿namespace EmployeeWebApi.Models.User
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public UserResult(UserModel user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.IsActive = user.IsActive;
        }
    }
}
