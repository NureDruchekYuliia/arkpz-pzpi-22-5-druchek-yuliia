using AutoMapper;
using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;

public class AddSleepRecordCommandHandler(ISleepRecordRepository sleepRecordRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<AddSleepRecordCommand, Guid>
{
    public async Task<Guid> Handle(AddSleepRecordCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var sleepRecord = mapper.Map<SleepRecord>(request);
        sleepRecord.UserId = currentUser.Id;

        Guid id = await sleepRecordRepository.Add(sleepRecord);
        return id;
    }
}
