using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandle(
    IEventRepository repository,
    IUnitOfWork unitOfWork,
    IEventPublicMapper mapper) 
    : IRequestHandler<UpdateEventCommand, ErrorOr<PublicEventDto>>
{
    public async Task<ErrorOr<PublicEventDto>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await repository.GetAsync(request.Id);

        if (eventToUpdate is null)
            return Error.Validation("Event", $"Event with id '{request.Id}' doesn't exist");
        
        Event newEvent = new Event
        {
            Id = request.Id,
            Name = request.Name,
            PlaceOrAddress = request.PlaceOrAddress,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            StartAt = request.StartAt,
            EndAt = request.EndAt,
            CreateDate = eventToUpdate.CreateDate,
            UpdateDate = DateTime.UtcNow,
            OrganizerId =  request.OrganizerId
        };
        
        var result = await repository.UpdateAsync(newEvent);
        
        if (result is null)
            return Error.Validation("Event", "Update event failed");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}