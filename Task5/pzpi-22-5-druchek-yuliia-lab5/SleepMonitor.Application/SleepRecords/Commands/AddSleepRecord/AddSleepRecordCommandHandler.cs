using AutoMapper;
using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;

public class AddSleepRecordCommandHandler(ISleepRecordRepository sleepRecordRepository,
    IIotDataRepository iotDataRepository, IMapper mapper, IUserContext userContext) : IRequestHandler<AddSleepRecordCommand, Guid>
{
    public async Task<Guid> Handle(AddSleepRecordCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var iotData = await iotDataRepository.GetAllByDateRangeAsync(
            currentUser.Id, request.SleepStart, request.SleepEnd);

        var avgNoiseLevel = iotData.Any() ? iotData.Average(data => data.NoiseLevel) : 0;
        var avgLightLevel = iotData.Any() ? iotData.Average(data => data.LightLevel) : 0;

        var sleepRecord = mapper.Map<SleepRecord>(request);
        sleepRecord.UserId = currentUser.Id;
        sleepRecord.AvgNoiseLevel = avgNoiseLevel;
        sleepRecord.AvgLightLevel = avgLightLevel;

        Guid id = await sleepRecordRepository.Add(sleepRecord);
        return id;
    }
}
