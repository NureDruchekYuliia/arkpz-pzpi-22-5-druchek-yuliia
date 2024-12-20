using MediatR;

namespace SleepMonitor.Application.SleepRecords.Commands.DeleteSleepRecord;

public class DeleteSleepRecordCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
