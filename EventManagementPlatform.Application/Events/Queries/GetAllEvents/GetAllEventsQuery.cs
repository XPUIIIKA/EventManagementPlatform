using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Domain.Entities;
using MediatR;

namespace EventManagementPlatform.Application.Events.Queries.GetAllEvents;

public record GetAllEventsQuery : IRequest<ErrorOr<IEnumerable<PublicEventDto>>>;