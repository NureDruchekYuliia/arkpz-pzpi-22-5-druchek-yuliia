using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;

namespace SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordsByDate;

public class GetSleepRecordsByDateQuery(DateOnly date) : IRequest<IEnumerable<SleepRecordDto>>
{

    public DateOnly Date { get; } = date!;
}
