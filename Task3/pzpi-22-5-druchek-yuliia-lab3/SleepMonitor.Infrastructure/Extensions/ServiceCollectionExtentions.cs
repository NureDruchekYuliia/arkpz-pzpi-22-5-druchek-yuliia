using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;
using SleepMonitor.Infrastructure.Persistence;
using SleepMonitor.Infrastructure.Repositories;
using SleepMonitor.Infrastructure.Seeders;

namespace SleepMonitor.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        services.AddDbContext<SleepMonitorDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentityApiEndpoints<User>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<SleepMonitorDbContext>();

        services.AddScoped<IRecommendationSeeder, RecommendationSeeder>();
        services.AddScoped<ISleepRecordRepository, SleepRecordRepository>();
        services.AddScoped<IIotDataRepository, IotDataRepository>();
        services.AddScoped<IRecommendationRepository, RecommendationRepository>();
    }
}
