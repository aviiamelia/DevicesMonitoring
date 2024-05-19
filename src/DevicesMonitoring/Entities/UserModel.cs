namespace DevicesMonitoring.Entities;

public class UserModel
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; }
    public ICollection<Device> Devices { get; set; }
}
