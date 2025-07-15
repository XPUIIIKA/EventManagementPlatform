using EventManagementPlatform.Domain.Entities.Base;

namespace EventManagementPlatform.Domain.Entities;

public class VisitorsInEvents : BaseEntityWithUpdate
{
    public required Guid VisitorId { get; init; }
    public Visitor? Visitor { get; set; }
    public required Guid EventId { get; init; }
    public Event? Event { get; set; }
    public Statuses Status { get; set; }
}