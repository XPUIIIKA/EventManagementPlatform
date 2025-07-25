﻿using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Queries.GetAllEvents;

public class GetAllEventsQueryHandler(
    IEventRepository repository,
    IEventPublicMapper mapper) 
    : IRequestHandler<GetAllEventsQuery, ErrorOr<IEnumerable<PublicEventDto>>>
{
    public async Task<ErrorOr<IEnumerable<PublicEventDto>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var events  = await repository.GetAllAsync(cancellationToken);
        
        if (events is null)
            return Error.Conflict("Event", "Events not found.");
        
        var result = events.ToList();
        
        if (result.Count == 0)
            return Error.Conflict("Event", "Events not found.");

        return result.Select(e => mapper.ToDto(e)).ToList();
    }
}