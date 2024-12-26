using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface ISleepRecordRepository
{
    Task<IEnumerable<SleepRecord>> GetAllByUserIdAsync(string userId);
    Task<IEnumerable<SleepRecord>> GetAllByDate(string userId, DateOnly date);
    Task<SleepRecord?> GetByIdAsync(Guid id);
    Task<bool> CheckUserId(Guid id, string userId);
    Task<Guid> Add(SleepRecord record);
    Task Delete(SleepRecord record);
    Task DeleteRecommendations(SleepRecord sleepRecord);
    Task SaveChanges();
}
