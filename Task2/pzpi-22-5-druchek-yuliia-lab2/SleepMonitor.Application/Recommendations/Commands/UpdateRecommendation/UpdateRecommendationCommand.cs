using MediatR;

namespace SleepMonitor.Application.Recommendations.Commands.UpdateRecommendation;

public class UpdateRecommendationCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
