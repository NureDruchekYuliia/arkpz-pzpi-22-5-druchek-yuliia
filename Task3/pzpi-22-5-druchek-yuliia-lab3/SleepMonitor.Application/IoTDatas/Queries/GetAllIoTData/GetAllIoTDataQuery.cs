using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;

namespace SleepMonitor.Application.IoTDatas.Queries.GetAllIoTData
{
    public class GetAllIoTDataQuery : IRequest<IEnumerable<IoTDataDto>>
    {
    }
}
