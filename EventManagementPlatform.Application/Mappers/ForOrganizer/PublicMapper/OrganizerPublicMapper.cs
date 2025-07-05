using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;

public class OrganizerPublicMapper : IOrganizerPublicMapper
{
    public PublicOrganizerDto ToDto(Organizer e)
    {
        return new PublicOrganizerDto
        {
            Id = e.Id,
            Name = e.Name,
            Surname = e.Surname
        };
    }
}