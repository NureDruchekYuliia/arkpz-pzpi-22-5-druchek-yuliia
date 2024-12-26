using MediatR;
using SleepMonitor.Application.SleepRecords.Dtos;

namespace SleepMonitor.Application.SleepRecords.Queries.GetAllSleepRecords;

public class GetAllSleepRecordsQuery : IRequest<IEnumerable<SleepRecordDto>>
{

}
