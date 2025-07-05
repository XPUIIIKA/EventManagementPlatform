using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;

public class EventPublicMapper :  IEventPublicMapper
{
    public PublicEventDto ToDto(Event e)
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