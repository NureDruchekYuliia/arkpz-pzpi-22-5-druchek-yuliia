using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> GetAllAsync();
    Task<Recommendation?> GetByIdAsync(Guid id);
    Task<IEnumerable<Recommendation>> GetBySleepRecordAsync(SleepRecord sleepRecord);
    Task<Guid> Add(Recommendation recommendation);
    Task AddToSleepRecord(Recommendation recommendation, SleepRecord sleepRecord);
    Task Delete(Recommendation recommendation);
    Task SaveChanges();
}

