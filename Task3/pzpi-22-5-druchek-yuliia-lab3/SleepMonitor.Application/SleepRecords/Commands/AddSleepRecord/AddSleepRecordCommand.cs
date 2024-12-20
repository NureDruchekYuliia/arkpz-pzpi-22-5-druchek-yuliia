
using MediatR;

namespace SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;

public class AddSleepRecordCommand : IRequest<Guid>
{
    public DateOnly Date { get; set; }
    public DateTime SleepStart { get; set; }
    public DateTime SleepEnd { get; set; }
    public int Quality { get; set; }
}
