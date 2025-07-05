using EventManagementPlatform.Domain.IRepositories;

namespace EventManagementPlatform.Infrastructure.Persistence.Repositories;

public class UnitOfWorkPostgres(EmpDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return context.SaveChangesAsync(ct);
    }
}