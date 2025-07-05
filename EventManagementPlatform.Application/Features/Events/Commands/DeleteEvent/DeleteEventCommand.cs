using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommand : IRequest<ErrorOr<PublicEventDto>>
{
    public Guid Id { get; init; }
}