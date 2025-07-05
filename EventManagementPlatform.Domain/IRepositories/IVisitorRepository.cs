using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IVisitorRepository
{
    public Task<Visitor?> AddNewEventAsync(Visitor vsitorToCreate);
    public Task<IEnumerable<Visitor>?> GetVisitorsByEventIdAsync(Guid eventId, CancellationToken cancellationToken);
    public Task<Visitor?> GetVisitorAsync(Guid id, CancellationToken cancellationToken);

}