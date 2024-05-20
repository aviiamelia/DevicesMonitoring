using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevicesMonitoring.Entities;

public class UserModel
{
    [Key]
    public int userid { get; set; }
    public string username { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string passwordhash { get; set; } = string.Empty;
    public DateTime createdat { get; set; }

    public ICollection<Device>? Devices { get; set; }
}
