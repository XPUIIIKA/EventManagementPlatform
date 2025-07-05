namespace EventManagementPlatform.Application.DTO.OrganizerDto;

public class PublicOrganizerDto
{
    public Guid Id { get; init; }
    // Max size 16.
    public required string Name { get; init; }
    // Max size 16.
    public required string Surname { get; init; }
}