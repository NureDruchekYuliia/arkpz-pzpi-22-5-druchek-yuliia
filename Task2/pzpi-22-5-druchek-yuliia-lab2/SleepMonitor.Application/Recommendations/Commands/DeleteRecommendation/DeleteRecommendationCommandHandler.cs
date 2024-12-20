using AutoMapper;
using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.Commands.DeleteRecommendation;

public class DeleteRecommendationCommandHandler(IRecommendationRepository recommendationRepository)
    : IRequestHandler<DeleteRecommendationCommand>
{
    public async Task Handle(DeleteRecommendationCommand request, CancellationToken cancellationToken)
    {
        var recommendation = await recommendationRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Recommendation), request.Id.ToString());

        await recommendationRepository.Delete(recommendation);
    }
}
