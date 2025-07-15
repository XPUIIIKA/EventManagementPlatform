using EventManagementPlatform.Domain.Entities.Base;

namespace EventManagementPlatform.Domain.Entities;

public class Event : BaseEntityWithUpdate
{
    // Max size 32.
    public required string Name { get; set; }
    // Max size 32
    public required string PlaceOrAddress { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required DateTime StartAt { get; set; }
    public required DateTime EndAt { get; set; }
    public required Guid OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
    public ICollection<VisitorsInEvents>? VisitorsInEvents { get; set; }
}