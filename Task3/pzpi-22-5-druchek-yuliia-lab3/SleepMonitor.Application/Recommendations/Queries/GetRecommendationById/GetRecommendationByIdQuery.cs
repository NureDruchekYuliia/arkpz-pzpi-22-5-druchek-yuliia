using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;

namespace SleepMonitor.Application.Recommendations.Queries.GetRecommendationById;

public class GetRecommendationByIdQuery(Guid id) : IRequest<RecommendationDto>
{
    public Guid Id { get; } = id;
}
