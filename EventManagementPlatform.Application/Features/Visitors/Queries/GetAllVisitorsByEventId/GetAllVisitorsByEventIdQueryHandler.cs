using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Queries.GetAllVisitorsByEventId;

public class GetAllVisitorsByEventIdQueryHandler(
    IVisitorRepository visitorRepository,
    IEventRepository eventRepository,
    IVisitorPublicMapper mapper
) : IRequestHandler<GetAllVisitorsByEventIdQuery, ErrorOr<IEnumerable<PublicVisitorDto>>>
{
    public async Task<ErrorOr<IEnumerable<PublicVisitorDto>>> Handle(GetAllVisitorsByEventIdQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await eventRepository.GetAsync(request.EventId);

        if (eventEntity is null)
            return Error.Validation("Event", "Event with the given id doesn't exist");
        
        var result = await visitorRepository.GetByEventIdAsync(request.EventId,  cancellationToken);
        
        if (result is  null)
            return Error.Conflict("Visitor", "Visitors with the given id doesn't exist");
        
        return result.Select(e => mapper.ToDto(e)).ToList();
    }
}