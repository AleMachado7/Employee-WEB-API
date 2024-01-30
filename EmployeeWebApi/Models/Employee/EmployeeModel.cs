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
        public DateTime? UpdateDate { get; set; }

        public static EmployeeModel Create(EmployeeParams createParams)
        {
            var model = new EmployeeModel
            {
                Name = createParams.Name,
                Surname = createParams.Surname,
                Department = createParams.Department,
                WorkShift = createParams.WorkShift
            };

            return model;
        }

        public void Update(EmployeeParams updateParams)
        {
            this.Name = updateParams.Name;
            this.Surname = updateParams.Surname;
            this.Department = updateParams.Department;
            this.WorkShift = updateParams.WorkShift;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }
    }
}
