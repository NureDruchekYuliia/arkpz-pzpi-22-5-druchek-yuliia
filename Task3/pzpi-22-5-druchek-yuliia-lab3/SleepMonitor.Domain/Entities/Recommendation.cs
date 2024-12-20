using SleepMonitor.Domain.Enums;

namespace SleepMonitor.Domain.Entities;

public class Recommendation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public PropertyType Property { get; set; } = default!; 
    public ComparisonType Comparison { get; set; } = default!; 
    public double Value { get; set; } = default!;
}
