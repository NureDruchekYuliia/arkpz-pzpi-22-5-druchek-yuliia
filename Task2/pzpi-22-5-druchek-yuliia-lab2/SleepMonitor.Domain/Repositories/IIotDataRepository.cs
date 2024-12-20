using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface IIotDataRepository
{
    Task<IEnumerable<IoTData>> GetAllByUserIdAsync(string userId);
    Task<IoTData?> GetByIdAsync(Guid id);
    Task<bool> CheckUserId(Guid id, string userId);
    Task<Guid> Add(IoTData iotData);
    Task Delete(IoTData iotData);
    Task SaveChanges();
}
