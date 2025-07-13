using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IEventRepository
{
    public Task<Event?> AddAsync(Event eventToCreate);
    public Task<IEnumerable<Event>?> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<IEnumerable<Event>?> GetAllByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    public Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<Event?> UpdateAsync(Event eventToUpdate);
    public Task<Event?> DeleteAsync(Guid id);
}