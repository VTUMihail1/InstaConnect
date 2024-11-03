using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;

public record GetUserDetailedByIdQuery(string Id) : IQuery<UserDetailedQueryViewModel>;
