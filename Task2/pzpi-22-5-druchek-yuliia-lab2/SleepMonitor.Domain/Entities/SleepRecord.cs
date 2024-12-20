namespace SleepMonitor.Domain.Entities;

public class SleepRecord
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public DateTime SleepStart { get; set; }
    public DateTime SleepEnd { get; set; }
    public TimeSpan Duration => SleepEnd - SleepStart;
    public int Quality { get; set; }
    public double AvgNoiseLevel { get; set; }
    public double AvgLightLevel { get; set; }

    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;

    public ICollection<SleepRecord_Recommendation>? SleepRecordRecommendations { get; set; }
}
