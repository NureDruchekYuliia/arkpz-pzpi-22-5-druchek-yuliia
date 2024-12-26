using SleepMonitor.Application.Recommendations.Dtos;
using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Application.SleepRecords.Dtos;

public class SleepRecordDto
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public DateTime SleepStart { get; set; }
    public DateTime SleepEnd { get; set; }
    public TimeSpan Duration => SleepEnd - SleepStart;
    public int Quality { get; set; }
    public double AvgNoiseLevel { get; set; }
    public double AvgLightLevel { get; set; }

}
