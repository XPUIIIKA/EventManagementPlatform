using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Queries.GetEvent;

public class GetEventQuery : IRequest<ErrorOr<PublicEventDto?>>
{
    public required Guid Id { get; init; }
}