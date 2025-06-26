using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;

namespace EventManagementPlatform.Application.IServices;

public interface IOrganizerService
{
    public ErrorOr<PublicOrganizerDto> CreateOrganizerAsync(CreateOrganizerDto dto, CancellationToken cancellationToken = default);
    public ErrorOr<IEnumerable<PublicOrganizerDto>> GetAllOrganizerAsync(CancellationToken cancellationToken);
    public ErrorOr<PublicOrganizerDto> GetOrganizerAsync(Guid id, CancellationToken cancellationToken);
    public ErrorOr<PublicOrganizerDto> UpdateOrganizerAsync(UpdateOrganizerDto dto, CancellationToken cancellationToken = default);
    public ErrorOr<PublicOrganizerDto> DeleteOrganizerAsync(Guid id, CancellationToken cancellationToken = default);
}