using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;

namespace SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordById;

public class GetSleepRecordByIdQuery(Guid id) : IRequest<SleepRecordDto>
{
    public Guid Id { get; } = id;
}
