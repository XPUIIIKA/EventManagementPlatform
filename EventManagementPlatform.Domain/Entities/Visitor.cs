using EventManagementPlatform.Domain.Entities.Base;

namespace EventManagementPlatform.Domain.Entities;

public class Visitor :  BaseEntity
{
    // Max size 16.
    public required string Name { get; set; }
    // Max size 16.
    public required string Surname { get; set; }
    // Max size 14
    public required string PhoneNumber { get; init; }
}