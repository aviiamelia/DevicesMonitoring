namespace DevicesMonitoring.DTO;

public class CreateDeviceDto
{
    public class DeviceResponseDTO
    {
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public DeviceResponseDTO(string deviceName, string deviceType, DateTime createdAt, int userId)
        {
            DeviceName = deviceName;
            DeviceType = deviceType;
            CreatedAt = createdAt;
            UserId = userId;
        }
    }
}
