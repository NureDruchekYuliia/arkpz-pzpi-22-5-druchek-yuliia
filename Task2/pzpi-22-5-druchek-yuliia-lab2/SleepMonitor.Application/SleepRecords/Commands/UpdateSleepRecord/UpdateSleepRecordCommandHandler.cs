using AutoMapper;
using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;

public class UpdateSleepRecordCommandHandler(ISleepRecordRepository sleepRecordRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<UpdateSleepRecordCommand>
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

        mapper.Map(request, sleepRecord);

        await sleepRecordRepository.SaveChanges();
    }
}
