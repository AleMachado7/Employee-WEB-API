namespace EmployeeWebApi.Models.Employee
{
    public class EmployeeResponse
    {
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
