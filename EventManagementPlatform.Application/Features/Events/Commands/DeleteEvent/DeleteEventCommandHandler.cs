using ErrorOr;
using EventManagementPlatform.Application.Features.Events.CommonDTO;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using MediatR;

namespace EventManagementPlatform.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler(
    IEventRepository repository,
    IUnitOfWork unitOfWork,
    IEventPublicMapper mapper) 
    : IRequestHandler<DeleteEventCommand, ErrorOr<PublicEventDto>>
{
    public async Task<ErrorOr<PublicEventDto>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteEventAsync(request.Id);

        if (result is null)
            return Error.Validation("Event", $"Event with id '{request.Id}' doesn't exist");

        await unitOfWork.SaveChangesAsync();
        
        return mapper.ToDto(result);
    }
}