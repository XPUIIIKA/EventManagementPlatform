using EventManagementPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementPlatform.Infrastructure.Persistence.Configurations;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.Property(e => e.PlaceOrAddress)
            .IsRequired()
            .HasMaxLength(32);
        
        // до 6 знаков после запятой (±1 м точность)
        builder.Property(e => e.Latitude)
            .HasPrecision(9, 6);
        
        // до 6 знаков после запятой (±1 м точность)
        builder.Property(e => e.Longitude)
            .HasPrecision(9, 6);
        
        builder.Property(e => e.StartAt)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
        builder.Property(e => e.EndAt)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
        builder.Property(e => e.OrganizerId)
            .IsRequired();

        builder.Property(e => e.CreateDate)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
        builder.Property(e => e.UpdateDate)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
        builder.HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId);

        builder.HasMany(e => e.VisitorsInEvents)
            .WithOne(v => v.Event)
            .HasForeignKey(v => v.EventId);
    }
}