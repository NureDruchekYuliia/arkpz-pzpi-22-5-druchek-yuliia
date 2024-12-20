using MediatR;

namespace SleepMonitor.Application.IoTDatas.Commands.AddIoTData;

public class AddIoTDataCommand : IRequest<Guid>
{
    public DateTime Time { get; set; }
    public double NoiseLevel { get; set; }
    public double LightLevel { get; set; }
}
