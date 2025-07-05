using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;

public interface IVisitorPublicMapper
{
    PublicVisitorDto ToDto(Visitor e);
}