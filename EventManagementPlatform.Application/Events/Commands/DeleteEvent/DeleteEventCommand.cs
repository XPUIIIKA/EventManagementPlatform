using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Domain.Entities;
using MediatR;

namespace EventManagementPlatform.Application.Events.Commands.DeleteEvent;

public class DeleteEventCommand : IRequest<ErrorOr<PublicEventDto>>
{
    public Guid Id { get; init; }
}