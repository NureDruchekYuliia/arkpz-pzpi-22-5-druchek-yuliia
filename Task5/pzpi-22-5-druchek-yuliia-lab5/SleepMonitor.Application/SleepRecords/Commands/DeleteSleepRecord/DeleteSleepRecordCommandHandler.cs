using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Commands.DeleteSleepRecord;

internal class DeleteSleepRecordCommandHandler(ISleepRecordRepository sleepRecordRepository, 
    IUserContext userContext) : IRequestHandler<DeleteSleepRecordCommand>
{
    public async Task Handle(DeleteSleepRecordCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var sleepRecord = await sleepRecordRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(SleepRecord), request.Id.ToString());

        var isUser = await sleepRecordRepository.CheckUserId(request.Id, currentUser.Id);

        if (!isUser)
        {
            throw new ForbidException();
        }
        
        await sleepRecordRepository.Delete(sleepRecord);
    }
}
