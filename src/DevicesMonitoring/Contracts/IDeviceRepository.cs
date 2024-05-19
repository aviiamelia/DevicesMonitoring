using DevicesMonitoring.Entities;

namespace DevicesMonitoring.Contracts;

public interface IDeviceRepository
{
    Device FindDevice(string deviceName);

    List<Device> ListAll();

    void Add(Device user);
}
