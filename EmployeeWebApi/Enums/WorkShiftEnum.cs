using System.Text.Json.Serialization;

namespace EmployeeWebApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WorkShiftEnum
    {
        Morning,
        Afternoon,
        Night
    }
}
