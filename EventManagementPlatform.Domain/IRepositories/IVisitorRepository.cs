using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IVisitorRepository
{
    public Task<Visitor?> AddAsync(Visitor vsitorToCreate);
    public Task<IEnumerable<Visitor>?> GetByEventIdAsync(Guid eventId, CancellationToken cancellationToken);
    public Task<Visitor?> GetAsync(Guid id, CancellationToken cancellationToken);

}