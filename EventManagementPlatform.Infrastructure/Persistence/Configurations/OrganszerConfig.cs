using EventManagementPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementPlatform.Infrastructure.Persistence.Configurations;

public class OrganszerConfig : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(16)
            .IsRequired();
        
        builder.Property(e => e.Surname)
            .HasMaxLength(16)
            .IsRequired();
        
        builder.Property(e => e.Login)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(e => e.HashPassword)
            .HasMaxLength(64)
            .IsRequired();
        
        builder.Property(e => e.Email)
            .HasMaxLength(64)
            .IsRequired();
        
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(14)
            .IsRequired();
        
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