using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;
using DevicesMonitoring.Services.LoggedUser;
namespace RocketseatAuction.Api.Services;

public class LoggedUser : IloggedUser
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;

        _repository = repository;
    }


    public UserModel User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return _repository.FindUser(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }
    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
