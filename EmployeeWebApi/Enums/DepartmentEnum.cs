using System.Text.Json.Serialization;

namespace EmployeeWebApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Finances,
        Purchasing,
        CustomerService,
        Janitorial
    }
}
