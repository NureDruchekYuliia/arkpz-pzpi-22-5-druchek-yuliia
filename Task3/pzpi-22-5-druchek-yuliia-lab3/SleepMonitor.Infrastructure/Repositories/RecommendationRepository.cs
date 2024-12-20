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

    public async Task AddToSleepRecord(Recommendation recommendation, SleepRecord sleepRecord)
    {
        var existingRelation = await dbContext.SleepRecord_Recommendations
        .AnyAsync(srr => srr.SleepRecordId == sleepRecord.Id && srr.RecommendationId == recommendation.Id);

        if (!existingRelation)
        {
            var sleepRecordRecommendation = new SleepRecord_Recommendation
            {
                SleepRecordId = sleepRecord.Id,
                RecommendationId = recommendation.Id
            };

            await dbContext.SleepRecord_Recommendations.AddAsync(sleepRecordRecommendation);
            await dbContext.SaveChangesAsync();
        }
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

    public async Task<IEnumerable<Recommendation>> GetBySleepRecordAsync(SleepRecord sleepRecord)
    {
        var recommendations = await dbContext.SleepRecords
        .Where(sr => sr.Id == sleepRecord.Id)
        .SelectMany(sr => sr.SleepRecordRecommendations)
        .Select(srr => srr.Recommendation)
        .ToListAsync();

        return recommendations;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
