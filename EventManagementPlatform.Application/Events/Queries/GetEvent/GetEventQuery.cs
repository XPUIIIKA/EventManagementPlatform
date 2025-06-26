using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using MediatR;

namespace EventManagementPlatform.Application.Events.Queries.GetEvent;

public class GetEventQuery : IRequest<ErrorOr<PublicEventDto?>>
{
    public required Guid Id { get; init; }
}