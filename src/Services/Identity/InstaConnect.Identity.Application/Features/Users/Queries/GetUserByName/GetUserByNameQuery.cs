using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;

public record GetUserByNameQuery(string UserName) : IQuery<UserQueryViewModel>;
