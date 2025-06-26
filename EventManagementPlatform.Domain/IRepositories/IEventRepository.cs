using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IEventRepository
{
    public Task<EventEntity?> AddNewEventAsync(EventEntity eventEntityToCreate);
    public Task<IEnumerable<EventEntity>?> GetAllEventsAsync(CancellationToken cancellationToken = default);
    public Task<IEnumerable<EventEntity>?> GetAllEventsByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    public Task<EventEntity?> GetEventAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<EventEntity?> UpdateEventAsync(EventEntity eventEntityToUpdate);
    public Task<EventEntity?> DeleteEventAsync(Guid id);
}