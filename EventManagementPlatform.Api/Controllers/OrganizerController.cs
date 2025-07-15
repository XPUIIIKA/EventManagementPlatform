using EventManagementPlatform.Api.Extensions;
using EventManagementPlatform.Application.Features.Organizers.Commands.CreateOrganizer;
using EventManagementPlatform.Application.Features.Organizers.Commands.DeleteOrganizer;
using EventManagementPlatform.Application.Features.Organizers.Commands.UpdateOrganizer;
using EventManagementPlatform.Application.Features.Organizers.Queries.GetAllOrganizer;
using EventManagementPlatform.Application.Features.Organizers.Queries.GetOrganizer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementPlatform.Api.Controllers;

[ApiController]
[Route("api/organizer")]
public class OrganizerController(IMediator mediator) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllOrganizersQuery());
        
        return result.GetIActionResult();
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetOrganizer([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetOrganizerQuery{ Id = id});
        
        return result.GetIActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> AddOrganizer([FromBody] CreateOrganizerCommand command)
    {
        var result = await mediator.Send(command);
        
        return result.GetIActionResult();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateOrganizer([FromBody] UpdateOrganizerCommand command)
    {
        var result = await mediator.Send(command);
        
        return result.GetIActionResult();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganizer([FromRoute] Guid id)
    {
        var result = await mediator.Send(new DeleteOrganizerCommand{ Id = id });
        
        return result.GetIActionResult();
    }
    
}
