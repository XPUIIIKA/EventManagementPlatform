using EventManagementPlatform.Api.Extensions;
using EventManagementPlatform.Application.Features.Visitors.Commands.CreateVisitor;
using EventManagementPlatform.Application.Features.Visitors.Queries.GetAllVisitorsByEventId;
using EventManagementPlatform.Application.Features.Visitors.Queries.GetVisitor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementPlatform.Api.Controllers;

[ApiController]
[Route("api/visitor")]
public class VisitorController(IMediator mediator) : ControllerBase
{
    [HttpGet("all/{eventId}")]
    public async Task<IActionResult> GetAllVisitorsByEventId([FromRoute] Guid eventId)
    {
        var result = await mediator.Send(new GetAllVisitorsByEventIdQuery{EventId = eventId});

        return result.GetIActionResult();
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetVisitor([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetVisitorQuery{Id = id});
        
        return result.GetIActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVisitor([FromBody] CreateVisitorCommand command)
    {
        var result = await mediator.Send(command);
        
        return result.GetIActionResult();
    }
    
}