﻿using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand : IRequest<ErrorOr<PublicEventDto>>
{
    // Max size 32.
    public required string Name { get; init; }
    // Max size 32
    public required string PlaceOrAddress { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public required Guid OrganizerId { get; init; }
    public required DateTime StartAt { get; init; }
    public required DateTime EndAt { get; init; }
}