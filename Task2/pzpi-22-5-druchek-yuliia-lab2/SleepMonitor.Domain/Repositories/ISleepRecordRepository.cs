using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface ISleepRecordRepository
{
    Task<IEnumerable<SleepRecord>> GetAllByUserIdAsync(string userId);
    Task<SleepRecord?> GetByIdAsync(Guid id);
    Task<bool> CheckUserId(Guid id, string userId);
    Task<Guid> Add(SleepRecord record);
    Task Delete(SleepRecord record);
    Task SaveChanges();
}
