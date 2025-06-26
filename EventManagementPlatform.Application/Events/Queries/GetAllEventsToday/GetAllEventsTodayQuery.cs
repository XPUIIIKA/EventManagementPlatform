using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using MediatR;

namespace EventManagementPlatform.Application.Events.Queries.GetAllEventsToday;

public record GetAllEventsTodayQuery : IRequest<ErrorOr<IEnumerable<PublicEventDto>>>;
