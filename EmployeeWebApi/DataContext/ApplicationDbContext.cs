using EmployeeWebApi.Models.Employee;
using EmployeeWebApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
