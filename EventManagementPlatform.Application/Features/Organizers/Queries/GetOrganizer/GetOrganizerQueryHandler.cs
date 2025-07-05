using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Queries.GetOrganizer;

public class GetOrganizerQueryHandler(
    IOrganizerRepository repository,
    IOrganizerPublicMapper mapper) : IRequestHandler<GetOrganizerQuery, ErrorOr<PublicOrganizerDto>>
{
    public async Task<ErrorOr<PublicOrganizerDto>> Handle(GetOrganizerQuery request, CancellationToken cancellationToken)
    {
        var organizer = await repository.GetOrganizerAsync(request.Id, cancellationToken);
        
        if (organizer is null)
            return Error.Validation("Organizer", $"Organizer with id '{request.Id}' doesn't exist");
        
        return mapper.ToDto(organizer);
    }
}