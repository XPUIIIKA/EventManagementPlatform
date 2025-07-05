using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IEventRepository
{
    public Task<Event?> AddNewEventAsync(Event eventToCreate);
    public Task<IEnumerable<Event>?> GetAllEventsAsync(CancellationToken cancellationToken = default);
    public Task<IEnumerable<Event>?> GetAllEventsByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    public Task<Event?> GetEventAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<Event?> UpdateEventAsync(Event eventToUpdate);
    public Task<Event?> DeleteEventAsync(Guid id);
}