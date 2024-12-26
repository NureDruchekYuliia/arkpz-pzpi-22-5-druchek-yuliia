using AutoMapper;
using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordsByDate;

internal class GetSleepRecordsByDateQueryHandler(ISleepRecordRepository sleepRecordRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<GetSleepRecordsByDateQuery, IEnumerable<SleepRecordDto>>
{
    public async Task<IEnumerable<SleepRecordDto>> Handle(GetSleepRecordsByDateQuery request, CancellationToken cancellationToken)
    {

        var currentUser = userContext.GetCurrentUser()!;
        var sleepRecords = await sleepRecordRepository.GetAllByDate(currentUser.Id, request.Date);
        var sleepRecordDto = mapper.Map<IEnumerable<SleepRecordDto>>(sleepRecords);

        return sleepRecordDto!;
    }
}
