﻿using EmployeeWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public WorkShiftEnum WorkShift { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpdateDate { get; set; }
    }
}
