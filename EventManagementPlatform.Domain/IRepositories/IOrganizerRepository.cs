using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Domain.IRepositories;

public interface IOrganizerRepository 
{
    public Task<Organizer?> AddNewEventAsync(Organizer organizerToCreate);
    public Task<IEnumerable<Organizer>?> GetAllOrganizersAsync(CancellationToken cancellationToken = default);
    public Task<Organizer?> GetOrganizerAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<Organizer?> UpdateOrganizerAsync(Organizer organizerToCreate);
    
    public Task<Organizer?> DeleteOrganizerAsync(Guid id);
}