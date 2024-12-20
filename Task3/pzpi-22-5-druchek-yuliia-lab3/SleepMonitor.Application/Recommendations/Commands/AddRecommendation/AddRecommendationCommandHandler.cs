using AutoMapper;
using MediatR;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Commands.AddRecommendation;

public class AddRecommendationCommandHandler(IRecommendationRepository recommendationRepository,
    IMapper mapper) : IRequestHandler<AddRecommendationCommand, Guid>
{
    public async Task<Guid> Handle(AddRecommendationCommand request, CancellationToken cancellationToken)
    {
        var recommendation = mapper.Map<Recommendation>(request);

        Guid id = await recommendationRepository.Add(recommendation);
        return id;
    }
}
