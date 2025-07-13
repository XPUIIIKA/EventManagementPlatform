using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class EventRepoPostgres(EmpDbContext context) : IEventRepository
{
    public async Task<Event?> AddAsync(Event eventToCreate)
    {
        try
        {
            return (await context.Events.AddAsync(eventToCreate)).Entity; 
        }
        catch
        {
            return null;
        }
    }

    public async Task<IEnumerable<Event>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Events.ToListAsync(cancellationToken); 
        }
        catch
        {
            return null;
        }
    }

    public async Task<IEnumerable<Event>?> GetAllByDateAsync(DateOnly date, CancellationToken cancellationToken = default)
    {
        try
        {
            var from = date.ToDateTime(TimeOnly.MinValue);
            var to = date.ToDateTime(TimeOnly.MaxValue);
            
            
            return await context.Events
                .Where(e => e.StartAt >= from && e.StartAt <= to)
                .ToListAsync(cancellationToken);
        }
        catch
        {
            return null;
        }
    }

    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Events.FirstOrDefaultAsync(e => e.Id == id,  cancellationToken);
        }
        catch
        {
            return null;
        }
    }

    public async Task<Event?> UpdateAsync(Event eventToUpdate)
    {
        try
        {
            var result = await context.Events.FirstOrDefaultAsync(e => e.Id == eventToUpdate.Id);

            if (result is null)
                return null;
            
            result.StartAt = eventToUpdate.StartAt;
            result.EndAt = eventToUpdate.EndAt;
            result.Latitude = eventToUpdate.Latitude;
            result.Longitude = eventToUpdate.Longitude;
            result.Name = eventToUpdate.Name;
            result.PlaceOrAddress = eventToUpdate.PlaceOrAddress;
            result.UpdateDate = DateTime.UtcNow;
            
            return result;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Event?> DeleteAsync(Guid id)
    {
        try
        {
            var eventToDelete = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToDelete is null)
                return null;
            
            return context.Events.Remove(eventToDelete).Entity;
        }
        catch
        {
            return null;
        }
    }
}