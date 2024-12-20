using Microsoft.EntityFrameworkCore;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;
using SleepMonitor.Infrastructure.Persistence;

namespace SleepMonitor.Infrastructure.Repositories;

internal class RecommendationRepository(SleepMonitorDbContext dbContext)
    : IRecommendationRepository
{
    public async Task<Guid> Add(Recommendation recommendation)
    {
        dbContext.Recommendations.Add(recommendation);
        await dbContext.SaveChangesAsync();
        return recommendation.Id;
    }

    public async Task Delete(Recommendation recommendation)
    {
        dbContext.Remove(recommendation);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Recommendation>> GetAllAsync()
    {
        var recommendations = await dbContext.Recommendations.ToListAsync();
        return recommendations;
    }

    public async Task<Recommendation?> GetByIdAsync(Guid id)
    {
        var recommendation = await dbContext.Recommendations.FirstOrDefaultAsync(x => x.Id == id);
        return recommendation;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
