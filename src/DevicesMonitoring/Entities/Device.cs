namespace DevicesMonitoring.Entities;

public class Device
{
    public int DeviceId { get; set; }
    public string DeviceName { get; set; } = string.Empty;
    public string DeviceType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
  
    public required UserModel User { get; set; }
}
