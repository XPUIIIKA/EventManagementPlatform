using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;

public interface IOrganizerPublicMapper
{
    PublicOrganizerDto ToDto(Organizer e);
}