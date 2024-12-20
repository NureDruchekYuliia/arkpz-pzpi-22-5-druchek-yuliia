namespace SleepMonitor.Application.Recommendations.CheckConditions;

public interface ICheckConditionsService
{
    Task GenerateRecommendations(Guid id);
}