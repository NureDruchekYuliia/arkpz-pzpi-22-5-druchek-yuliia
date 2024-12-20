using AutoMapper;
using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.IoTDatas.Commands.AddIoTData;

public class AddIoTDataCommandHandler(IIotDataRepository iotDataRepository,
    IMapper mapper, IUserContext userContext) : IRequestHandler<AddIoTDataCommand, Guid>
{
    public async Task<Guid> Handle(AddIoTDataCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var iotData = mapper.Map<IoTData>(request);
        iotData.UserId = currentUser.Id;

        Guid id = await iotDataRepository.Add(iotData);
        return id;
    }
}
