using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;

namespace SleepMonitor.Application.IoTDatas.Queries.GetIoTDataById;

public class GetIoTDataByIdQuery(Guid id) : IRequest<IoTDataDto>
{
    public Guid Id { get; } = id;
}
