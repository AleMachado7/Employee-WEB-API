using EmployeeWebApi.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
