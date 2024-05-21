using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;
using DevicesMonitoring.Services.LoggedUser;
using static DevicesMonitoring.DTO.CreateDeviceDto;

namespace DevicesMonitoring.useCases.CreateDevice;

public class CreateDeviceUseCase
{
    public readonly IDeviceRepository _repository;
    public readonly IloggedUser _loggedUser;
    public CreateDeviceUseCase(IDeviceRepository repo, IloggedUser loggedUser)
    {
        _repository = repo;
        _loggedUser = loggedUser;
    }
    public DeviceResponseDTO Execute(RequestCreateDevice request)
    {
        var user = _loggedUser.User();
        var device = new Device
        {
            devicename = request.devicename,
            devicetype = request.devicetype,    
            createdat = DateTime.UtcNow,
            userid = user.userid


        };
        var deviceResponseDTO = new DeviceResponseDTO(device.devicename, device.devicetype, device.createdat, device.userid);
        _repository.Add(device);

        return deviceResponseDTO;
    }
}
