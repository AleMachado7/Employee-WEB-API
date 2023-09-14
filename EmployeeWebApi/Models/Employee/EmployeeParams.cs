using EmployeeWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models.Employee
{
    public class EmployeeParams
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DepartmentEnum Department { get; set; }
        public WorkShiftEnum WorkShift { get; set; }
    }
}
