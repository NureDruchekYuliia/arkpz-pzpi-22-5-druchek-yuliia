using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;

namespace SleepMonitor.Application.Recommendations.Queries.GetRecommendationsBySleepRecord;

public class GetRecommendationsBySleepRecordQuery(Guid sleepRecordId) : IRequest<IEnumerable<RecommendationDto>>
{
    public Guid SleepRecordId { get; } = sleepRecordId;
}
