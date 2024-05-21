using DevicesMonitoring.Contracts;
using DevicesMonitoring.Entities;

namespace DevicesMonitoring.Repositories.dataAccess;

public class DeviceRepository : IDeviceRepository
{
    private readonly MyDbContext _dbContext;
    public DeviceRepository(MyDbContext dbContext) => _dbContext = dbContext;
    public Device FindDevice(string deviceName)
    {
        var device = _dbContext.devices.First(device => device.devicename.Equals(deviceName));
        return device;
    }

    public List<Device> ListAll()
    {

        var devices = _dbContext.devices.ToList();

        return devices;

    }

    public void Add(Device device)
    {
        _dbContext.devices.Add(device);
        _dbContext.SaveChanges();
    }

    public List<Device> ListByUser(int userid)
    {
        var devices = _dbContext.devices.Where(device => device.userid.Equals(userid)).ToList();
        return devices;

    }
}
