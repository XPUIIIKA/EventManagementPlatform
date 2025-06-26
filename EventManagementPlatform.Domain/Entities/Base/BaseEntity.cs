namespace EventManagementPlatform.Domain.Entities.Base;

public class BaseEntity
{
    public required Guid Id { get; init; }
    public required DateTime CreateDate { get; init; }
}