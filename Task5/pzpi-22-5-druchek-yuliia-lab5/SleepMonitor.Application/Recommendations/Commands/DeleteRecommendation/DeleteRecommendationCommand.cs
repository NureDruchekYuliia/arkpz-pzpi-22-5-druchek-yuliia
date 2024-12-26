using MediatR;

namespace SleepMonitor.Application.Recommendations.Commands.DeleteRecommendation;

public class DeleteRecommendationCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}

