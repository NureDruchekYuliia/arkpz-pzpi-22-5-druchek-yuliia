using AutoMapper;
using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.SleepRecords.Queries.GetAllSleepRecords;

public class GetAllSleepRecordsQueryHandler (ISleepRecordRepository sleepRecordRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<GetAllSleepRecordsQuery, IEnumerable<SleepRecordDto>> 
{
    public async Task<IEnumerable<SleepRecordDto>> Handle(GetAllSleepRecordsQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;
        var sleepRecords = await sleepRecordRepository.GetAllByUserIdAsync(currentUser.Id);
        var sleepRecordDto = mapper.Map<IEnumerable<SleepRecordDto>>(sleepRecords);

        return sleepRecordDto!;
    }
}
