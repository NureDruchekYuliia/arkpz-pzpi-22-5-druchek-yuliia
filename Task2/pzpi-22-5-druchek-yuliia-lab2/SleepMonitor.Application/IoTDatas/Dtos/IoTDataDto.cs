namespace SleepMonitor.Application.IoTDatas.Dtos;

public class IoTDataDto
{
    public Guid Id { get; set; }
    public DateTime Time { get; set; }
    public double NoiseLevel { get; set; }
    public double LightLevel { get; set; }
}
