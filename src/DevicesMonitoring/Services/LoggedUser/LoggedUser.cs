using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;
using DevicesMonitoring.Services.jwtToken;

namespace DevicesMonitoring.Services.LoggedUser;
public class LoggedUser : IloggedUser
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    private readonly JwtToken _tokenService;
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository, JwtToken jwt)
    {
        _httpContextAccessor = httpContext;
        _tokenService = jwt;
        _repository = repository;
    }


    public UserModel User()
    {
        var token = TokenOnRequest();
        var email = _tokenService.GetEmailFromToken(token);

        return _repository.FindUser(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }

}
