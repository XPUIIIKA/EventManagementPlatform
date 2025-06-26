using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.Event.PublicMapper;

public class EventPublicMapper :  IEventPublicMapper
{
    public PublicEventDto ToDto(EventEntity e)
    {
        return new PublicEventDto
        {
            Id = e.Id,
            Name = e.Name,
            PlaceOrAddress = e.PlaceOrAddress,
            Latitude = e.Latitude,
            Longitude = e.Longitude,
            StartAt = e.StartAt,
            EndAt = e.EndAt,
        };
    }
}