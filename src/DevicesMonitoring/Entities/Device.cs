namespace DevicesMonitoring.Entities;

public class Device
{
    public int deviceid { get; set; }
    public string devicename { get; set; } = string.Empty;
    public string devicetype { get; set; } = string.Empty;
    public DateTime createdat { get; set; }

    public int userid { get; set; }

    public UserModel user { get; set; }
}
