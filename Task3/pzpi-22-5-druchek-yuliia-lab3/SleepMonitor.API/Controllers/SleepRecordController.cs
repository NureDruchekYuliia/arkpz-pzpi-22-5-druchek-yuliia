using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SleepMonitor.Application.Recommendations.CheckConditions;
using SleepMonitor.Application.Recommendations.Queries.GetRecommendationsBySleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.DeleteSleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;
using SleepMonitor.Application.SleepRecords.Queries.GetAllSleepRecords;
using SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordById;
using SleepMonitor.Application.SleepRecords.Queries.GetSleepRecordsByDate;
using SleepMonitor.Domain.Constants;


namespace SleepMonitor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = UserRoles.User)]
public class SleepRecordController(IMediator mediator, ICheckConditionsService checkConditionsService) : ControllerBase
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

    [HttpGet("recommendations/{id}")]
    public async Task<IActionResult> GetRecommendations([FromRoute] Guid id)
    {
        var recommendation = await mediator.Send(new GetRecommendationsBySleepRecordQuery(id));
        if (recommendation is null)
            return NotFound();

        return Ok(recommendation);
    }

    [HttpGet("date/{date}")]
    public async Task<IActionResult> GetRecommendations([FromRoute] DateOnly date)
    {
        var recommendation = await mediator.Send(new GetSleepRecordsByDateQuery(date));
        if (recommendation is null)
            return NotFound();

        return Ok(recommendation);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSleepRecord([FromRoute] Guid id, UpdateSleepRecordCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        await checkConditionsService.GenerateRecommendations(id);

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
        await checkConditionsService.GenerateRecommendations(id);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
