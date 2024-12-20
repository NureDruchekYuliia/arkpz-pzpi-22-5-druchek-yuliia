using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SleepMonitor.Application.Recommendations.Commands.AddRecommendation;
using SleepMonitor.Application.Recommendations.Commands.DeleteRecommendation;
using SleepMonitor.Application.Recommendations.Commands.UpdateRecommendation;
using SleepMonitor.Application.Recommendations.Queries.GetAllRecommendations;
using SleepMonitor.Application.Recommendations.Queries.GetRecommendationById;
using SleepMonitor.Application.Recommendations.Queries.GetRecommendationsBySleepRecord;
using SleepMonitor.Domain.Constants;

namespace SleepMonitor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = UserRoles.Admin)]
public class RecommendationController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var recommendations = await mediator.Send(new GetAllRecommendationsQuery());
        return Ok(recommendations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var recommendation = await mediator.Send(new GetRecommendationByIdQuery(id));
        if (recommendation is null)
            return NotFound();

        return Ok(recommendation);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateRecommendation([FromRoute] Guid id, UpdateRecommendationCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecommendation([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteRecommendationCommand(id));

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddRecommendation(AddRecommendationCommand command)
    {
        Guid id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}

