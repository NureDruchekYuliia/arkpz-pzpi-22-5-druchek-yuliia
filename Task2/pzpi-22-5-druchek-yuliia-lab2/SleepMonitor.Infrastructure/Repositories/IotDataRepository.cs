using Microsoft.EntityFrameworkCore;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;
using SleepMonitor.Infrastructure.Persistence;

namespace SleepMonitor.Infrastructure.Repositories;

internal class IotDataRepository(SleepMonitorDbContext dbContext)
    : IIotDataRepository
{
    public async Task<Guid> Add(IoTData iotData)
    {
        dbContext.IoTData.Add(iotData);
        await dbContext.SaveChangesAsync();
        return iotData.Id;
    }

    public async Task Delete(IoTData iotData)
    {
        dbContext.Remove(iotData);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<IoTData>> GetAllByUserIdAsync(string userId)
    {
        var iotData = await dbContext.IoTData
            .Where(iotData => iotData.UserId == userId)
            .ToListAsync();
        return iotData;
    }

    public async Task<IoTData?> GetByIdAsync(Guid id)
    {
        var iotData = await dbContext.IoTData.FirstOrDefaultAsync(x => x.Id == id);
        return iotData;
    }

    public async Task<bool> CheckUserId(Guid id, string userId)
    {
        var iotData = await dbContext.IoTData.FirstOrDefaultAsync(x => x.Id == id);
        return iotData.UserId == userId;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
