using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;
using System.Security.Cryptography;
using System.Text;

namespace DevicesMonitoring.useCases.CreateUser;

public class CreateUserUseCase
{
    public readonly IUserRepository _repo;

    public CreateUserUseCase(IUserRepository repo)
    {
        _repo = repo;
    }
     public UserModel Execute(RequestCreateUser request) {

        var hashed = HashPassword(request.passwordhash);
        var user = new UserModel
        {
            username = request.username,
            email = request.email,
            passwordhash = hashed,
            createdat = DateTime.UtcNow,

        };
        _repo.Add(user);
        UserModel userWithoutPassword = new UserModel { userid = user.userid, username = user.username, email = user.email };
        return userWithoutPassword;
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
