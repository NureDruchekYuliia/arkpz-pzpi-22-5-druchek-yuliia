using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.DeleteSleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;
using SleepMonitor.Application.SleepRecords.Queries.GetAllSleepRecords;
using SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordById;
using SleepMonitor.Domain.Constants;


namespace SleepMonitor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = UserRoles.User)]
public class SleepRecordController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sleepRecords = await mediator.Send(new GetAllSleepRecordsQuery());
        return Ok(sleepRecords);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var sleepRecord = await mediator.Send(new GetSleepRecordByIdQuery(id));
        if (sleepRecord is null)
            return NotFound();

        return Ok(sleepRecord);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSleepRecord([FromRoute] Guid id, UpdateSleepRecordCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSleepRecord([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteSleepRecordCommand(id));

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddSleepRecord(AddSleepRecordCommand command)
    {
        Guid id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
