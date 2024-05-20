namespace DevicesMonitoring.Comunications.Request;

public class RequestCreateUser
{
    public string username { get; set; } = string.Empty;
    public string passwordhash { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
}
