using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Queries.GetAllOrganizer;

public class GetAllOrganizersQueryHandler(
    IOrganizerRepository repository,
    IOrganizerPublicMapper mapper)
    : IRequestHandler<GetAllOrganizersQuery, ErrorOr<IEnumerable<PublicOrganizerDto>>>
{

    public async Task<ErrorOr<IEnumerable<PublicOrganizerDto>>> Handle(GetAllOrganizersQuery request, CancellationToken cancellationToken)
    {
        var organizers = await repository.GetAllAsync(cancellationToken);
        
        if (organizers is null)
            return Error.Conflict("Organizer", "Organizers not found.");
                
        var result = organizers.ToList();
        
        if (result.Count == 0)
            return Error.Conflict("Event", "Events not found.");

        return result.Select(e => mapper.ToDto(e)).ToList();
        
    }
}