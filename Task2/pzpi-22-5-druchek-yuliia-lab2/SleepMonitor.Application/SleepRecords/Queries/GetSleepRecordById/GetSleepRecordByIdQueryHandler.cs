using AutoMapper;
using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordById;

public class GetSleepRecordByIdQueryHandler(ISleepRecordRepository sleepRecordRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<GetSleepRecordByIdQuery, SleepRecordDto>
{
    public async Task<SleepRecordDto> Handle(GetSleepRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var sleepRecord = await sleepRecordRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(SleepRecord), request.Id.ToString());

        var isUser = await sleepRecordRepository.CheckUserId(request.Id, currentUser.Id);

        if (!isUser)
        {
            throw new ForbidException();
        }

        var sleepRecordDto = mapper.Map<SleepRecordDto>(sleepRecord);

        return sleepRecordDto;
    }
}
