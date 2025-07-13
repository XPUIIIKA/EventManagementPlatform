using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class VisitorRepoPostgres(EmpDbContext context) : IVisitorRepository
{
    public async Task<Visitor?> AddAsync(Visitor vsitorToCreate)
    {
        try
        {
            var newVisitor = await context.Visitors.AddAsync(vsitorToCreate);
            return newVisitor.Entity;
        }
        catch
        {
            return null;
        }
    }
    public async Task<IEnumerable<Visitor>?> GetByEventIdAsync(Guid eventId, CancellationToken cancellationToken)
    {
        try
        {
            return await context.Visitors.ToListAsync(cancellationToken);
        }
        catch
        {
            return null;
        }
    }
    public async Task<Visitor?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            return await context.Visitors.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }
        catch
        {
            return null;
        }
    }
}
