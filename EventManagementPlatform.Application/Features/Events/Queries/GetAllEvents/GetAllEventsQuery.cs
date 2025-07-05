using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Queries.GetAllEvents;

public record GetAllEventsQuery : IRequest<ErrorOr<IEnumerable<PublicEventDto>>>;