using MediatR;

namespace SleepMonitor.Application.Recommendations.Commands.AddRecommendation;

public class AddRecommendationCommand : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
