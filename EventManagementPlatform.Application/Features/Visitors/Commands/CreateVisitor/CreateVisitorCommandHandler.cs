using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Commands.CreateVisitor;

public class CreateVisitorCommandHandler(
    IVisitorInEventRepository visitorInEventRepository,
    IVisitorRepository visitorRepository,
    IUnitOfWork unitOfWork,
    IVisitorPublicMapper mapper) : IRequestHandler<CreateVisitorCommand, ErrorOr<PublicVisitorDto>>
{
    public async Task<ErrorOr<PublicVisitorDto>> Handle(CreateVisitorCommand request, CancellationToken cancellationToken)
    {
        Visitor newVisitor = new Visitor
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            PhoneNumber = request.PhoneNumber,
            CreateDate = DateTime.UtcNow
        };
        
        var visitor = await visitorRepository.AddAsync(newVisitor);
        
        if (visitor is null)
            return Error.Conflict("Visitor", "Create visitor failed.");

        var result = await visitorInEventRepository.AddVisitorInEventAsync(visitor,  request.EventId);
        
        if (result is null)
            return Error.Conflict("Visitor", "Create VisitorInEvent failed.");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(visitor);
    }
}