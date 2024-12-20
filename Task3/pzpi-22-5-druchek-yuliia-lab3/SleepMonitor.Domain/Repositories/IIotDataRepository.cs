using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface IIotDataRepository
{
    Task<IEnumerable<IoTData>> GetAllByUserIdAsync(string userId);
    Task<IoTData?> GetByIdAsync(Guid id);
    Task<IEnumerable<IoTData?>> GetAllByDateRangeAsync(string userId, DateTime start, DateTime end);
    Task<bool> CheckUserId(Guid id, string userId);
    Task<Guid> Add(IoTData iotData);
    Task Delete(IoTData iotData);
    Task SaveChanges();
}
