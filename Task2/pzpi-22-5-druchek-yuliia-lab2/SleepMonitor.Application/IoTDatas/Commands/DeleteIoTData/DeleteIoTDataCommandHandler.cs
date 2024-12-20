using MediatR;
using SleepMonitor.Application.Users;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.IoTDatas.Commands.DeleteIoTData;

public class DeleteIoTDataCommandHandler(IIotDataRepository iotDataRepository,
    IUserContext userContext) : IRequestHandler<DeleteIoTDataCommand>
{
    public async Task Handle(DeleteIoTDataCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;

        var iotData = await iotDataRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(IoTData), request.Id.ToString());

        var isUser = await iotDataRepository.CheckUserId(request.Id, currentUser.Id);

        if (!isUser)
        {
            throw new ForbidException();
        }

        await iotDataRepository.Delete(iotData);
    }
}
