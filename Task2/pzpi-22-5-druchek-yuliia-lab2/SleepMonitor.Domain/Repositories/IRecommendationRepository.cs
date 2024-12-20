using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Domain.Repositories;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> GetAllAsync();
    Task<Recommendation?> GetByIdAsync(Guid id);
    Task<Guid> Add(Recommendation recommendation);
    Task Delete(Recommendation recommendation);
    Task SaveChanges();
}

