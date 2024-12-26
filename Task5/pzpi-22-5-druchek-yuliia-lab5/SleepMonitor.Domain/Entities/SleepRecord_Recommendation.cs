 namespace SleepMonitor.Domain.Entities;

public class SleepRecord_Recommendation
{
    public Guid SleepRecordId { get; set; }
    public SleepRecord SleepRecord { get; set; } = default!;

    public Guid RecommendationId { get; set; }
    public Recommendation Recommendation { get; set; } = default!;

}
