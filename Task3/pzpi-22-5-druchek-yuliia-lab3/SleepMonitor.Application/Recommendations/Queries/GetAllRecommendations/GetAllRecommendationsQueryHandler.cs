using AutoMapper;
using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.SleepRecords.Queries.GetAllSleepRecords;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Queries.GetAllRecommendations;
public class GetAllRecommendationsQueryHandler(IRecommendationRepository recommendationRepository,
IMapper mapper) : IRequestHandler<GetAllRecommendationsQuery, IEnumerable<RecommendationDto>>
{
    public async Task<IEnumerable<RecommendationDto>> Handle(GetAllRecommendationsQuery request, CancellationToken cancellationToken)
    {
        var recommendations = await recommendationRepository.GetAllAsync();
        var recommendationDto = mapper.Map<IEnumerable<RecommendationDto>>(recommendations);

        return recommendationDto!;
    }
}

