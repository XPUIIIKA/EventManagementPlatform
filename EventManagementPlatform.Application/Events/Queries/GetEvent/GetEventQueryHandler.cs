using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Application.Mappers.Event.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Events.Queries.GetEvent;

public class GetEventQueryHandler(
    IEventRepository repository,
    IEventPublicMapper mapper) : IRequestHandler<GetEventQuery, ErrorOr<PublicEventDto?>>
{
    public async Task<ErrorOr<PublicEventDto?>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var progEvent = await repository.GetEventAsync(request.Id, cancellationToken);
        
        if (progEvent is null)
            return Error.Validation("Event", $"Event with id '{request.Id}' doesn't exist");
        
        return mapper.ToDto(progEvent);
    }
}