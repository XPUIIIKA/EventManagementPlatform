using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Application.Interfaces;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Commands.UpdateOrganizer;

public class UpdateOrganizerCommandHandler(
    IOrganizerRepository repository,
    IUnitOfWork unitOfWork,
    IHasher hasher,
    IOrganizerPublicMapper mapper
    ) : IRequestHandler<UpdateOrganizerCommand, ErrorOr<PublicOrganizerDto>>
{
    public async Task<ErrorOr<PublicOrganizerDto>> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
    {
        var oldOrganizer = await repository.GetOrganizerAsync(request.Id);
        
        if (oldOrganizer is null)
            return Error.Validation("Organizer", "Organizer not found");
        
        Organizer organizerToUpdate = new Organizer
        {
            Id = request.Id,
            Name = request.Name,
            Surname = request.Surname,
            Login = request.Login,
            HashPassword = hasher.GetHash(request.Password),
            Email = request.Email,
            CreateDate = oldOrganizer.CreateDate,
            UpdateDate = DateTime.UtcNow,
            PhoneNumber = oldOrganizer.PhoneNumber
        };
        
        var organizer = await repository.UpdateOrganizerAsync(organizerToUpdate);

        if (organizer is null)
            return Error.Conflict("Organizer", "Organizer update failed");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(organizer);
    }
}