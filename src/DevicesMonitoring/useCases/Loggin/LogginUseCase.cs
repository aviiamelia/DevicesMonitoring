using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.Contracts;
using DevicesMonitoring.Services.jwtToken;
using System.Security.Cryptography;
using System.Text;

namespace DevicesMonitoring.useCases.Loggin;

public class LogginUseCase
{
    public readonly IUserRepository _repo;
    private readonly JwtToken _tokenService;

    public LogginUseCase(IUserRepository repo, JwtToken jwt)
    {
        _repo = repo;
        _tokenService = jwt;
    }

    public string execute(RequestLoggin request)
    {
        var user = _repo.FindUser(request.email);
        if (user == null)
        {
            throw new ArgumentException("User not found");
        }
        var requestHashed = HashPassword(request.passwordhash);
        if(user.passwordhash != requestHashed)
        {
            throw new ArgumentException("Wrong password");
        }
        string token = _tokenService.GenerateToken(user.email);
        return token;

    }
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInput = HashPassword(password);
        return hashedInput.Equals(hashedPassword);
    }
}
