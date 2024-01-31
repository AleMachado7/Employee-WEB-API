namespace EmployeeWebApi.Models.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
