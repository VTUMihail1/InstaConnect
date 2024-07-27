using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserById;

public record GetUserByIdQuery(string Id) : IQuery<UserQueryViewModel>;
