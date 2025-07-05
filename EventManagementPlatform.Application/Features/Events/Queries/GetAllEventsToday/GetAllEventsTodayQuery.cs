using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Queries.GetAllEventsToday;

public record GetAllEventsTodayQuery : IRequest<ErrorOr<IEnumerable<PublicEventDto>>>;
