using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;

public interface IEventPublicMapper
{
    PublicEventDto ToDto(Event e);
}