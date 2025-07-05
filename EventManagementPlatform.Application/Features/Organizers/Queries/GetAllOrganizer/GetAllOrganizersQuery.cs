using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Queries.GetAllOrganizer;

public record GetAllOrganizersQuery : IRequest<ErrorOr<IEnumerable<PublicOrganizerDto>>>;