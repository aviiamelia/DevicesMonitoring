using DevicesMonitoring.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DevicesMonitoring.Services.jwtToken;

namespace DevicesMonitoring.filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{

    private readonly IUserRepository _repository;
    private readonly JwtToken _jwtService;
    public AuthenticationUserAttribute(IUserRepository userRepository, JwtToken jwt)
    {
        _repository = userRepository;
        _jwtService = jwt;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var decodeEmail = _jwtService.GetEmailFromToken(token);
            var exist = _repository.ExistUserWithEmail(decodeEmail);
            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("email not valid");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }

    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("missing token");
        }
        return authentication["Bearer ".Length..];
    }
    private string FromBase128String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}

