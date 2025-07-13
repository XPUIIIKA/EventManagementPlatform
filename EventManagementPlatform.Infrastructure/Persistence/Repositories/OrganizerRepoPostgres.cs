using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class OrganizerRepoPostgres(EmpDbContext context) : IOrganizerRepository
{
    public async Task<Organizer?> AddAsync(Organizer organizerToCreate)
    {
        return (await context.Organizers.AddAsync(organizerToCreate)).Entity;
    }

    public async Task<IEnumerable<Organizer>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Organizers.ToListAsync(cancellationToken);
    }

    public async Task<Organizer?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Organizers.FirstOrDefaultAsync(organizer => organizer.Id == id, cancellationToken);
    }

    public async Task<Organizer?> UpdateAsync(Organizer organizerToUpdate)
    {
        var result = await context.Organizers.FirstOrDefaultAsync(organizer => organizer.Id == organizerToUpdate.Id);
        
        if (result is null)
            return null;
        
        result.Name = organizerToUpdate.Name;
        result.Surname = organizerToUpdate.Surname;
        result.Login = organizerToUpdate.Login;
        result.HashPassword = organizerToUpdate.HashPassword;
        result.Email = organizerToUpdate.Email;
        
        return result;
    }

    public async Task<Organizer?> DeleteAsync(Guid id)
    {
        var result = await context.Organizers.FirstOrDefaultAsync(organizer => organizer.Id == id);
        
        if (result is null)
            return null;
        
        context.Organizers.Remove(result);
        
        return result;
    }
}