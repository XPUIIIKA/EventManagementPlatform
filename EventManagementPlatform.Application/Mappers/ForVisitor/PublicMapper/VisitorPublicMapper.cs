using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;

public class VisitorPublicMapper : IVisitorPublicMapper
{
    public PublicVisitorDto ToDto(Visitor e)
    {
        return new PublicVisitorDto
        {
            Id = e.Id,
            Name = e.Name,
            Surname = e.Surname,
            PhoneNumber = e.PhoneNumber,
        };
    }
}