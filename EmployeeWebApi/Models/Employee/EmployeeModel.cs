using EmployeeWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models.Employee
{
    public partial class EmployeeModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; } = true;
        public WorkShiftEnum WorkShift { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }

        public static EmployeeModel Create(EmployeeParams createParams)
        {
            var model = new EmployeeModel();

            model.Name = createParams.Name;
            model.Surname = createParams.Surname;
            model.Department = createParams.Department;
            model.WorkShift = createParams.WorkShift;

            return model;
        }
    }
}
