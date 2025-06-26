using ErrorOr;
using EventManagementPlatform.Application.DTO.EventsDto;

namespace EventManagementPlatform.Application.IServices;

public interface IEventService
{
    public ErrorOr<PublicEventDto> CreateEventAsync(CreateEventDto dto, CancellationToken cancellationToken = default);
    public ErrorOr<IEnumerable<PublicEventDto>> GetAllEventsAsync(CancellationToken cancellationToken);
    public ErrorOr<IEnumerable<PublicEventDto>> GetAllEventsTodayAsync(CancellationToken cancellationToken);
    public ErrorOr<PublicEventDto> GetEventAsync(Guid id, CancellationToken cancellationToken);
    public ErrorOr<PublicEventDto> UpdateEventAsync(UpdateEventDto dto, CancellationToken cancellationToken = default);
    public ErrorOr<PublicEventDto> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default);
}