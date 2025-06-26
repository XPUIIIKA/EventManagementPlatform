using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.Event.PublicMapper;

public interface IEventPublicMapper
{
    PublicEventDto ToDto(EventEntity e);
}