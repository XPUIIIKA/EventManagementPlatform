using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class VisitorRepoPostgres(EmpDbContext context) : IVisitorRepository
{
    public async Task<Visitor?> AddNewEventAsync(Visitor vsitorToCreate)
    {
        var newVisitor = await context.Visitors.AddAsync(vsitorToCreate);
        return newVisitor.Entity;
    }

    public async Task<IEnumerable<Visitor>?> GetVisitorsByEventIdAsync(Guid eventId, CancellationToken cancellationToken)
    {
        return await context.Visitors.ToListAsync(cancellationToken);
    }

    public async Task<Visitor?> GetVisitorAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Visitors.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);;
    }
}
