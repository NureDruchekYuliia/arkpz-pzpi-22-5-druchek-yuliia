namespace SleepMonitor.Domain.Entities;

public class Recommendation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
