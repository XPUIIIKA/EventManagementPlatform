﻿using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Queries.GetAllEventsToday;

public class GetAllEventsTodayQueryHandler(
    IEventRepository repository,
    IEventPublicMapper mapper)
    :  IRequestHandler<GetAllEventsTodayQuery, ErrorOr<IEnumerable<PublicEventDto>>>
{
    public async Task<ErrorOr<IEnumerable<PublicEventDto>>> Handle(GetAllEventsTodayQuery request, CancellationToken cancellationToken)
    {
        var events = await repository.GetAllByDateAsync(DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
        
        if (events  is null)
            return Error.NotFound("Event", "Events not found.");
        
        var result = events.ToList();
        
        if (result.Count == 0)
            return Error.NotFound("Event", "Events not found.");

        return result.Select(e => mapper.ToDto(e)).ToList();
    }
}