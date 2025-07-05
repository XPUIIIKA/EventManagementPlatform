using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(
    IEventRepository repository,
    IUnitOfWork unitOfWork,
    IEventPublicMapper mapper) 
    : IRequestHandler<CreateEventCommand, ErrorOr<PublicEventDto>>
{
    public async Task<ErrorOr<PublicEventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Event eventToCreate = new Event
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            PlaceOrAddress = request.PlaceOrAddress,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            StartAt = request.StartAt,
            EndAt = request.EndAt,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow,
            OrganizerId = request.OrganizerId
        };
        
        var result = await repository.AddNewEventAsync(eventToCreate);

        if (result is null)
            return Error.Conflict("Event", "Create event failed.");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}