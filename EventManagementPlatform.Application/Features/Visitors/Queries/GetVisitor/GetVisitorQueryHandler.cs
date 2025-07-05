using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Queries.GetVisitor;

public class GetVisitorQueryHandler(
    IVisitorRepository repository,
    IVisitorPublicMapper mapper
) : IRequestHandler<GetVisitorQuery, ErrorOr<PublicVisitorDto>>
{
    public async Task<ErrorOr<PublicVisitorDto>> Handle(GetVisitorQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetVisitorAsync(request.VisitorId,  cancellationToken);
        
        if (result is  null)
            return Error.Conflict("Visitor", "Visitors with the given id doesn't exist");
        
        return mapper.ToDto(result);
    }
}