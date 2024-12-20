using AutoMapper;
using MediatR;
using SleepMonitor.Application.Recommendations.Dtos;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Queries.GetRecommendationById;

public class GetRecommendationByIdQueryHandler(IRecommendationRepository recommendationRepository,
    IMapper mapper) : IRequestHandler<GetRecommendationByIdQuery, RecommendationDto>
{
    public async Task<RecommendationDto> Handle(GetRecommendationByIdQuery request, CancellationToken cancellationToken)
    {

        var recommendation = await recommendationRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(SleepRecord), request.Id.ToString());

        var recommendationDto = mapper.Map<RecommendationDto>(recommendation);

        return recommendationDto;
    }
}
