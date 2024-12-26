using MediatR;
using SleepMonitor.Domain.Enums;

namespace SleepMonitor.Application.Recommendations.Commands.UpdateRecommendation;

public class UpdateRecommendationCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public PropertyType Property { get; set; } = default!;
    public ComparisonType Comparison { get; set; } = default!;
    public double Value { get; set; } = default!;
}
