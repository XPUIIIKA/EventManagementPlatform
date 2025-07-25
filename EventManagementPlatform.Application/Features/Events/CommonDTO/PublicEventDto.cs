﻿namespace EventManagementPlatform.Application.Features.Events.CommonDTO;

public class PublicEventDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string PlaceOrAddress { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public required DateTime StartAt { get; init; }
    public required DateTime EndAt { get; init; }
}