using Microsoft.EntityFrameworkCore;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;
using SleepMonitor.Infrastructure.Persistence;

namespace SleepMonitor.Infrastructure.Repositories;

internal class SleepRecordRepository(SleepMonitorDbContext dbContext) 
    : ISleepRecordRepository
{
    public async Task<Guid> Add(SleepRecord record)
    {
        dbContext.SleepRecords.Add(record);
        await dbContext.SaveChangesAsync();
        return record.Id;
    }

    public async Task Delete(SleepRecord record)
    {
        dbContext.Remove(record);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteRecommendations(SleepRecord sleepRecord)
    {
        var recommendations = dbContext.SleepRecord_Recommendations
            .Where(srr => srr.SleepRecordId == sleepRecord.Id);
        dbContext.SleepRecord_Recommendations.RemoveRange(recommendations);

        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<SleepRecord>> GetAllByUserIdAsync(string userId)
    {
        var sleepRecords = await dbContext.SleepRecords
            .Where(record => record.UserId == userId)
            .ToListAsync();
        return sleepRecords;
    }

    public async Task<IEnumerable<SleepRecord>> GetAllByDate(string userId, DateOnly date)
    {
        var sleepRecords = await dbContext.SleepRecords
            .Where(record => record.UserId == userId)
            .Where(record => record.Date == date)
            .ToListAsync();
        return sleepRecords;
    }

    public async Task<SleepRecord?> GetByIdAsync(Guid id)
    {
        var sleepRecord = await dbContext.SleepRecords.FirstOrDefaultAsync(x => x.Id == id);
        return sleepRecord;
    }

    public async Task<bool> CheckUserId(Guid id, string userId)
    {
        var sleepRecord = await dbContext.SleepRecords.FirstOrDefaultAsync(x => x.Id == id);
        return sleepRecord.UserId == userId;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
