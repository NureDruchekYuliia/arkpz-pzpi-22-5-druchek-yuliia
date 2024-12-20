using SleepMonitor.Infrastructure.Extensions;
using SleepMonitor.Infrastructure.Seeders;
using SleepMonitor.Application.Extensions;
using SleepMonitor.Domain.Entities;
using SleepMonitor.API.Extensions;
using SleepMonitor.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRecommendationSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline. 

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
