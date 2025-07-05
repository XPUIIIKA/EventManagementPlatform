using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Commands.DeleteOrganizer;

public class DeleteOrganizerCommand : IRequest<ErrorOr<PublicOrganizerDto>>
{
    public Guid Id { get; init; }
}