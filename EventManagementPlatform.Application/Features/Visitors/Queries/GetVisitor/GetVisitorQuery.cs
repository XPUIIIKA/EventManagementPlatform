using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Queries.GetVisitor;

public class GetVisitorQuery : IRequest<ErrorOr<PublicVisitorDto>>
{
    public Guid Id { get; init; }
}