using EventManagementPlatform.Domain.Entities.Base;

namespace EventManagementPlatform.Domain.Entities;

public class Organizer : BaseEntityWithUpdate
{
    // Max size 16.
    public required string Name { get; set; }
    // Max size 16.
    public required string Surname { get; set; }
    // Max size 32.
    public required string Login { get; set; }
    // Max size 64.
    public required string HashPassword { get; set; }
    // Max size 64
    public required string Email { get; set; }
    // Max size 14
    public required string PhoneNumber { get; init; }
}