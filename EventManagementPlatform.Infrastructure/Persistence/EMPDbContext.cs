using EventManagementPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Infrastructure.Persistence;

public class EmpDbContext : DbContext
{
    public EmpDbContext(DbContextOptions<EmpDbContext> options) :
        base(options) {}

    public DbSet<Event> Events { get; set; } 
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<VisitorsInEvents>  VisitorsInEvents { get; set; }
    public DbSet<Organizer> Organizers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}