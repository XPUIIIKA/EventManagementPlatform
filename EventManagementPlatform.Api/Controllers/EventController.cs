using EventManagementPlatform.Api.Extensions;
using EventManagementPlatform.Application.Features.Events.Commands.CreateEvent;
using EventManagementPlatform.Application.Features.Events.Commands.DeleteEvent;
using EventManagementPlatform.Application.Features.Events.Commands.UpdateEvent;
using EventManagementPlatform.Application.Features.Events.Queries.GetAllEvents;
using EventManagementPlatform.Application.Features.Events.Queries.GetAllEventsToday;
using EventManagementPlatform.Application.Features.Events.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementPlatform.Api.Controllers;

[ApiController]
[Route("api/event")]
public class EventController(IMediator mediator) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllEventsQuery());
        
        return result.GetIActionResult();
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetEvent([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetEventQuery { Id = id });
        
        return result.GetIActionResult();
    }

    [HttpGet("today")]
    public async Task<IActionResult> GetEventToday()
    {
        var result = await mediator.Send(new GetAllEventsTodayQuery());
        
        return result.GetIActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] CreateEventCommand command)
    {
        var result = await mediator.Send(command);
        
        return result.GetIActionResult();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand command)
    {
        var result = await mediator.Send(command);
        
        return result.GetIActionResult();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
    {
        var result = await mediator.Send(new DeleteEventCommand { Id = id });
        
        return result.GetIActionResult();
    }
}