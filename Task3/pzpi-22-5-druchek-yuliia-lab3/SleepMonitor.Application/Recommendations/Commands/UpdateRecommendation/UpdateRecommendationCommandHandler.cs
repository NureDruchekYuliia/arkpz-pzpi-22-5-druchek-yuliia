using AutoMapper;
using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Commands.UpdateRecommendation;

public class UpdateRecommendationCommandHandler(IRecommendationRepository recommendationRepository,
    IMapper mapper) : IRequestHandler<UpdateRecommendationCommand>
{
    public async Task Handle(UpdateRecommendationCommand request, CancellationToken cancellationToken)
    {
        var recommendation = await recommendationRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Recommendation), request.Id.ToString());

        mapper.Map(request, recommendation);

        await recommendationRepository.SaveChanges();
    }
}
