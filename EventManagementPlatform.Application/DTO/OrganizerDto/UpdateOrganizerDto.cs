namespace EventManagementPlatform.Application.DTO.OrganizerDto;

public class UpdateOrganizerDto
{
    public required Guid Id { get; init; }
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
}