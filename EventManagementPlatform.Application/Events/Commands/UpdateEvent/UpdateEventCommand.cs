using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Domain.Entities;
using MediatR;

namespace EventManagementPlatform.Application.Events.Commands.UpdateEvent;

public class UpdateEventCommand : IRequest<ErrorOr<PublicEventDto>>
{
    public required Guid Id { get; init; }
    // Max size 32.
    public required string Name { get; init; }
    // Max size 32
    public required string PlaceOrAddress { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public required DateTime StartAt { get; init; }
    public required DateTime EndAt { get; init; }
    public required Guid OrganizerId { get; init; }
}