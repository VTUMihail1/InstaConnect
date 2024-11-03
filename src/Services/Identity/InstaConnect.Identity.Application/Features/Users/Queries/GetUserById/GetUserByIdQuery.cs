using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;

public record GetUserByIdQuery(string Id) : IQuery<UserQueryViewModel>;
