using ErrorOr;
using EventManagementPlatform.Application.DTO.VisitorDto;

namespace EventManagementPlatform.Application.IServices;

public interface IVisitorService
{
    public ErrorOr<PublicVisitorDto> CreateVisitorAsync(CreateVisitorDto dto, CancellationToken cancellationToken = default);
    public ErrorOr<IEnumerable<PublicVisitorDto>> GetAllVisitorsByEventIdAsync(Guid id, CancellationToken cancellationToken);
    public ErrorOr<PublicVisitorDto> GetVisitorAsync(Guid id, CancellationToken cancellationToken);
}