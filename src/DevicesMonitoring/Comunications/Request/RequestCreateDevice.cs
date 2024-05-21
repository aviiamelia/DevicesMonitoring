using DevicesMonitoring.Entities;

namespace DevicesMonitoring.Comunications.Request;

public class RequestCreateDevice
{
    public string devicename { get; set; } = string.Empty;
    public string devicetype { get; set; } = string.Empty;
    public int userid { get; set; }

}
