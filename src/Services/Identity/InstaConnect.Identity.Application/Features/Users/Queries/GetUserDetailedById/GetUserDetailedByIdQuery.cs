using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetUserDetailedById;

public record GetUserDetailedByIdQuery(string Id) : IQuery<UserDetailedQueryViewModel>;
