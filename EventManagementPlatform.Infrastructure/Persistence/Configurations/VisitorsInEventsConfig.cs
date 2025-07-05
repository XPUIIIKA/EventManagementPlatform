using EventManagementPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementPlatform.Infrastructure.Persistence.Configurations;

public class VisitorsInEventsConfig : IEntityTypeConfiguration<VisitorsInEvents>
{
    
    public void Configure(EntityTypeBuilder<VisitorsInEvents> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.VisitorId)
            .IsRequired();
        
        builder.Property(x => x.EventId)
            .IsRequired();
        
        builder.HasOne(x => x.Visitor)
            .WithMany()
            .HasForeignKey(x => x.VisitorId);
        
        builder.HasOne(x => x.Event)
            .WithMany()
            .HasForeignKey(x => x.EventId);

        builder.Property(e => e.CreateDate)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
        builder.Property(e => e.UpdateDate)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
    }
}