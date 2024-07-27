using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;

public record GetUserDetailedByIdQuery(string Id) : IQuery<UserDetailedQueryViewModel>;
