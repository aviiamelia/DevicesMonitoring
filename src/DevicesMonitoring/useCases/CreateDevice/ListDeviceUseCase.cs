using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;
using DevicesMonitoring.Services.LoggedUser;

namespace DevicesMonitoring.useCases.CreateDevice;

public class ListDeviceUseCase
{
    public readonly IDeviceRepository _repository;
    public readonly IloggedUser _loggedUser;
    public ListDeviceUseCase(IDeviceRepository repo, IloggedUser loggedUser)
    {
        _repository = repo;
        _loggedUser = loggedUser;
    }
    public List<Device> Execute()
    {
        var user = _loggedUser.User();
        var devices = _repository.ListByUser(user.userid);
        return devices;
    }
}
