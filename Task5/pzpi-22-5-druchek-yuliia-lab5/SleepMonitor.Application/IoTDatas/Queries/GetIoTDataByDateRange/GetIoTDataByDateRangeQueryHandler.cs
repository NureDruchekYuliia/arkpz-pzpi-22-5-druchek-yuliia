using AutoMapper;
using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.IoTDatas.Queries.GetIoTDataByDateRange;

public class GetIoTDataByDateRangeQueryHandler(IIotDataRepository iotDataRepository,
IMapper mapper, IUserContext userContext) : IRequestHandler<GetIoTDataByDateRangeQuery, IEnumerable<IoTDataDto>>
{
    public async Task<IEnumerable<IoTDataDto>> Handle(GetIoTDataByDateRangeQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;
        var iotData = await iotDataRepository.GetAllByDateRangeAsync(currentUser.Id, request.StartDate, request.EndDate);
        var iotDataDto = mapper.Map<IEnumerable<IoTDataDto>>(iotData);

        return iotDataDto!;
    }
}
