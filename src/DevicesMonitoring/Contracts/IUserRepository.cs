using DevicesMonitoring.Entities;

namespace DevicesMonitoring.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    UserModel FindUser(string email);

    List<UserModel> ListAll();

    void Add(UserModel user);
}
