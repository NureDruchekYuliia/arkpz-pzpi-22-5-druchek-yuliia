using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;

public class UpdateSleepRecordCommandHandler(ISleepRecordRepository sleepRecordRepository,
    IIotDataRepository iotDataRepository, IUserContext userContext) : IRequestHandler<UpdateSleepRecordCommand>
{
    public async Task Handle(UpdateSleepRecordCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var sleepRecord = await sleepRecordRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(SleepRecord), request.Id.ToString());

        var isUser = await sleepRecordRepository.CheckUserId(request.Id, currentUser.Id);

        if (!isUser)
        {
            throw new ForbidException();
        }

        if (request.SleepStart != default && request.SleepEnd != default)
        {
            var iotData = await iotDataRepository.GetAllByDateRangeAsync(
                currentUser.Id, request.SleepStart, request.SleepEnd);

            sleepRecord.AvgNoiseLevel = iotData.Any() ? iotData.Average(data => data.NoiseLevel) : 0;
            sleepRecord.AvgLightLevel = iotData.Any() ? iotData.Average(data => data.LightLevel) : 0;
            sleepRecord.SleepStart = request.SleepStart;
            sleepRecord.SleepEnd = request.SleepEnd;
        }

        if (request.Date != default)
            sleepRecord.Date = request.Date;

        if (request.Quality != default)
            sleepRecord.Quality = request.Quality;

        await sleepRecordRepository.DeleteRecommendations(sleepRecord);

        await sleepRecordRepository.SaveChanges();
    }
}
