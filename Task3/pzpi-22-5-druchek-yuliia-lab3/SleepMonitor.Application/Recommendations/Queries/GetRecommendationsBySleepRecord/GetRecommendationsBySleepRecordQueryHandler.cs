using AutoMapper;
using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Queries.GetRecommendationsBySleepRecord;

internal class GetRecommendationsBySleepRecordQueryHandler(IRecommendationRepository recommendationRepository,
ISleepRecordRepository sleepRecordRepository, IMapper mapper) : IRequestHandler<GetRecommendationsBySleepRecordQuery, IEnumerable<RecommendationDto>>
{
    public async Task<IEnumerable<RecommendationDto>> Handle(GetRecommendationsBySleepRecordQuery request, CancellationToken cancellationToken)
    {
        var sleepRecord = await sleepRecordRepository.GetByIdAsync(request.SleepRecordId)
            ?? throw new NotFoundException(nameof(SleepRecord), request.SleepRecordId.ToString());

        var recommendations = await recommendationRepository.GetBySleepRecordAsync(sleepRecord);
        var recommendationDto = mapper.Map<IEnumerable<RecommendationDto>>(recommendations);

        return recommendationDto!;
    }
}
