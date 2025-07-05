using EventManagementPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementPlatform.Infrastructure.Persistence.Configurations;

public class VisitorConfig : IEntityTypeConfiguration<Visitor>
{
    public void Configure(EntityTypeBuilder<Visitor> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(16)
            .IsRequired();
        
        builder.Property(e => e.Surname)
            .HasMaxLength(16)
            .IsRequired();
        
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(14)
            .IsRequired();
        
        builder.Property(e => e.CreateDate)
            .HasColumnType("timestamp with time zone")
            .HasPrecision(0)
            .IsRequired();
        
    }
}