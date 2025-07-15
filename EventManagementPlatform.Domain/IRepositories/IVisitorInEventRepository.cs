using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IVisitorInEventRepository
{
    Task<VisitorsInEvents?> AddVisitorInEventAsync(Visitor visitor, Guid eventId);
}