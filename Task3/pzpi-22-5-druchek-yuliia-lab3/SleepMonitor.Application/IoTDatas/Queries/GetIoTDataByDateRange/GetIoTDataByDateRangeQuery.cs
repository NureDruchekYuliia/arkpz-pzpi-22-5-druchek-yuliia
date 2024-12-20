using MediatR;
using SleepMonitor.Application.IoTDatas.Dtos;

namespace SleepMonitor.Application.IoTDatas.Queries.GetIoTDataByDateRange;

public class GetIoTDataByDateRangeQuery(DateTime startDate, DateTime endDate) : IRequest<IEnumerable<IoTDataDto>>
{
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
}