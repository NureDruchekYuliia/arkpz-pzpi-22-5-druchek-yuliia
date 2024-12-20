using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SleepMonitor.Application.IoTDatas.Commands.AddIoTData;
using SleepMonitor.Application.IoTDatas.Commands.DeleteIoTData;
using SleepMonitor.Application.IoTDatas.Queries.GetAllIoTData;
using SleepMonitor.Application.IoTDatas.Queries.GetIoTDataByDateRange;
using SleepMonitor.Application.IoTDatas.Queries.GetIoTDataById;
using SleepMonitor.Domain.Constants;
using System;

namespace SleepMonitor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = UserRoles.User)]
public class IoTDataController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var iotData = await mediator.Send(new GetAllIoTDataQuery());
        return Ok(iotData);
    }

    [HttpGet("range")]
    public async Task<IActionResult> GetAllByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var iotData = await mediator.Send(new GetIoTDataByDateRangeQuery(startDate, endDate));
        return Ok(iotData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var iotData = await mediator.Send(new GetIoTDataByIdQuery(id));
        if (iotData is null)
            return NotFound();

        return Ok(iotData);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIotData([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteIoTDataCommand(id));

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddIotData(AddIoTDataCommand command)
    {
        Guid id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
