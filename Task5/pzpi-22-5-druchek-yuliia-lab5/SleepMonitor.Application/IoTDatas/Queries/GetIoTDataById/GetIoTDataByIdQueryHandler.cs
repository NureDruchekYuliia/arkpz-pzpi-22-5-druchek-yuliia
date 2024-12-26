using AutoMapper;
using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.IoTDatas.Queries.GetIoTDataById;

public class GetIoTDataByIdQueryHandler(IIotDataRepository iotDataRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<GetIoTDataByIdQuery, IoTDataDto>
{
    public async Task<IoTDataDto> Handle(GetIoTDataByIdQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var iotData = await iotDataRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(IoTData), request.Id.ToString());

        var isUser = await iotDataRepository.CheckUserId(request.Id, currentUser.Id);

        if (!isUser)
        {
            throw new ForbidException();
        }

        var iotDataDto = mapper.Map<IoTDataDto>(iotData);

        return iotDataDto;
    }
}
