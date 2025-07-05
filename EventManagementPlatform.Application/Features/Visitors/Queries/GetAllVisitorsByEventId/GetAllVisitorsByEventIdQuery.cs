using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Queries.GetAllVisitorsByEventId;

public class GetAllVisitorsByEventIdQuery : IRequest<ErrorOr<IEnumerable<PublicVisitorDto>>>
{
    public Guid EventId { get; init; }
}