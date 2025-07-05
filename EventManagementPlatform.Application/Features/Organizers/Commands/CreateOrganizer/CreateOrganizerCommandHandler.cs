using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using EventManagementPlatform.Application.Interfaces;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Commands.CreateOrganizer;

public class CreateOrganizerCommandHandler(
    IOrganizerRepository repository,
    IUnitOfWork unitOfWork,
    IHasher hasher,
    IOrganizerPublicMapper mapper) : IRequestHandler<CreateOrganizerCommand, ErrorOr<PublicOrganizerDto>>
{
    public async Task<ErrorOr<PublicOrganizerDto>> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
    {
        Organizer newOrganizers = new Organizer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            Login = request.Login,
            HashPassword = hasher.GetHash(request.Password),
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };
        
        var result = await repository.AddNewEventAsync(newOrganizers);
        
        if (result is null)
            return Error.Conflict("Organizer", "Create organizer failed.");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}