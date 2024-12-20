using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;

namespace SleepMonitor.Application.Recommendations.Queries.GetAllRecommendations;

public class GetAllRecommendationsQuery : IRequest<IEnumerable<RecommendationDto>>
{
}
