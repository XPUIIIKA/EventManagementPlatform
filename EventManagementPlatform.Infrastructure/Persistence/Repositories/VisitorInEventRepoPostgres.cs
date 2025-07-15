using EventManagementPlatform.Domain;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class VisitorInEventRepoPostgres(EmpDbContext context) : IVisitorInEventRepository
{
    public async Task<VisitorsInEvents?> AddVisitorInEventAsync(Visitor visitor, Guid eventId)
    {
        try
        {
            var visitorInEvent = new VisitorsInEvents
            {
                Id = Guid.NewGuid(),
                EventId = eventId,
                VisitorId = visitor.Id,
                Status = Statuses.Accepted,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
        
            var result = (await context.VisitorsInEvents.AddAsync(visitorInEvent)).Entity;
        
            return result;
        }
        catch
        {
            return null;
        }

    }
}