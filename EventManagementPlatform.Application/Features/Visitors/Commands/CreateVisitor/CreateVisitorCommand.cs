using ErrorOr;
using EventManagementPlatform.Application.Features.Visitors.CommonDTO;
using MediatR;

namespace EventManagementPlatform.Application.Features.Visitors.Commands.CreateVisitor;

public class CreateVisitorCommand : IRequest<ErrorOr<PublicVisitorDto>>
{
    // Max size 16.
    public required string Name { get; init; }
    // Max size 16.
    public required string Surname { get; init; }
    // Max size 14
    public required string PhoneNumber { get; init; }
}