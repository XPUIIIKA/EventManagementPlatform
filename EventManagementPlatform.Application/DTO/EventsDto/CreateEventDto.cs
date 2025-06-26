namespace EventManagementPlatform.Application.DTO.EventsDto;

public class CreateEventDto
{
    // Max size 32.
    public required string Name { get; init; }
    // Max size 32
    public required string PlaceOrAddress { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public required DateTime StartAt { get; init; }
    public required DateTime EndAt { get; init; }
}