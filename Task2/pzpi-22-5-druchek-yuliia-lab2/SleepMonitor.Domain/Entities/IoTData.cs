namespace SleepMonitor.Domain.Entities;

public class IoTData
{
    public Guid Id { get; set; }
    public DateTime Time { get; set; }
    public double NoiseLevel { get; set; }
    public double LightLevel { get; set; }

    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
