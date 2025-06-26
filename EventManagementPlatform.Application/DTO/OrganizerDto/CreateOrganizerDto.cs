namespace EventManagementPlatform.Application.DTO.OrganizerDto;

public class CreateOrganizerDto
{
    // Max size 16.
    public required string Name { get; init; }
    // Max size 16.
    public required string Surname { get; init; }
    // Max size 32.
    public required string Login { get; init; }
    // Max size 64.
    public required string Password { get; init; }
    // Max size 64
    public required string Email { get; init; }
    // Max size 14
    public required string PhoneNumber { get; init; }
}