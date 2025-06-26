using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;
using ErrorOr;
using EventManagementPlatform.Application.Events.Common;
using EventManagementPlatform.Application.Mappers.Event.PublicMapper;

namespace EventManagementPlatform.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(
    IEventRepository repository,
    IUnitOfWork unitOfWork,
    IEventPublicMapper mapper) 
    : IRequestHandler<CreateEventCommand, ErrorOr<PublicEventDto>>
{
    public async Task<ErrorOr<PublicEventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        EventEntity eventEntityToCreate = new EventEntity
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
        
        var result = await repository.AddNewEventAsync(eventEntityToCreate);

        if (result is null)
            return Error.Conflict("Event", "Create event failed.");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}