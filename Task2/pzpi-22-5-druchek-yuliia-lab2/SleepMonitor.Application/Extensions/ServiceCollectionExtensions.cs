using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SleepMonitor.Application.SleepRecords;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor();
    }    
}
