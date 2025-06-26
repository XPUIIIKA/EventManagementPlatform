namespace EventManagementPlatform.Application.DTO.VisitorDto;

public class PublicVisitorDto
{
    public required Guid Id { get; init; }
    // Max size 16.
    public required string Name { get; init; }
    // Max size 16.
    public required string Surname { get; init; }
    // Max size 14
    public required string PhoneNumber { get; init; }
}