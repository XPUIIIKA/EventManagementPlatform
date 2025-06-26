namespace EventManagementPlatform.Domain.Entities.Base;

public class BaseEntityWithUpdate : BaseEntity
{
    public DateTime UpdateDate { get; set; }
}