using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

public record GetDetailedUserByIdQuery(string Id) : IQuery<UserDetailedQueryViewModel>;
