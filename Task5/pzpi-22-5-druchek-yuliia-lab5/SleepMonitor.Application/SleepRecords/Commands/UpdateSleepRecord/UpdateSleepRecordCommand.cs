using MediatR;

namespace SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;

public class UpdateSleepRecordCommand : IRequest
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public DateTime SleepStart { get; set; }
    public DateTime SleepEnd { get; set; }
    public int Quality { get; set; }
}
