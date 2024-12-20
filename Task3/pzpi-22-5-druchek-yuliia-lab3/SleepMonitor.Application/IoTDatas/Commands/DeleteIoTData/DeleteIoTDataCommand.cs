using MediatR;

namespace SleepMonitor.Application.IoTDatas.Commands.DeleteIoTData;

public class DeleteIoTDataCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}