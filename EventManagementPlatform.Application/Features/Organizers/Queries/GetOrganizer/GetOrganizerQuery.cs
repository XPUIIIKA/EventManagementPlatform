﻿using ErrorOr;
using EventManagementPlatform.Application.DTO.OrganizerDto;
using MediatR;

namespace EventManagementPlatform.Application.Features.Organizers.Queries.GetOrganizer;

public class GetOrganizerQuery : IRequest<ErrorOr<PublicOrganizerDto>>
{
    public Guid Id { get; init; }
}