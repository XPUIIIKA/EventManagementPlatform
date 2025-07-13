using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IOrganizerRepository 
{
    public Task<Organizer?> AddAsync(Organizer organizerToCreate);
    public Task<IEnumerable<Organizer>?> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<Organizer?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<Organizer?> UpdateAsync(Organizer organizerToUpdate);
    
    public Task<Organizer?> DeleteAsync(Guid id);
}