using AutoMapper;
using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.IoTDatas.Queries.GetAllIoTData;

public class GetAllIoTDataQueryHandler(IIotDataRepository iotDataRepository,
IMapper mapper, IUserContext userContext) : IRequestHandler<GetAllIoTDataQuery, IEnumerable<IoTDataDto>>
{
    public async Task<IEnumerable<IoTDataDto>> Handle(GetAllIoTDataQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;
        var iotData = await iotDataRepository.GetAllByUserIdAsync(currentUser.Id);
        var iotDataDto = mapper.Map<IEnumerable<IoTDataDto>>(iotData);

        return iotDataDto!;
    }
}
