using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Commands.DeleteOrganizer;

public class DeleteOrganizerCommandHandler(
    IOrganizerRepository repository,
    IUnitOfWork unitOfWork,
    IOrganizerPublicMapper mapper) : IRequestHandler<DeleteOrganizerCommand, ErrorOr<PublicOrganizerDto>>
{
    public async Task<ErrorOr<PublicOrganizerDto>> Handle(DeleteOrganizerCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteOrganizerAsync(request.Id);

        if (result is null)
            return Error.Validation("Organizer", $"Organizer with id '{request.Id}' doesn't exist");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}