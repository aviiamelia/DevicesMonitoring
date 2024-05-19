using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;

namespace DevicesMonitoring.Repositories.dataAccess;

public class UserRepository : IUserRepository
{
    private readonly MyDbContext _dbContext;

    public UserRepository(MyDbContext dbContext) => _dbContext = dbContext;
    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.users.Any(user => user.email.Equals(email));
    }

    public UserModel FindUser(string email)
    {
        var user = _dbContext.users.First(user => user.email.Equals(email));
        return user;
    }

    public List<UserModel> ListAll()
    {

        var users = _dbContext.users.ToList();

        return users;

    }

    public void Add(UserModel user)
    {
        _dbContext.users.Add(user);
        _dbContext.SaveChanges();
    }
}
