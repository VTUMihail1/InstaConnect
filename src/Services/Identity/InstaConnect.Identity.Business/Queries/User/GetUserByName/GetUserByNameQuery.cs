using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetUserByName;

public record GetUserByNameQuery(string UserName) : IQuery<UserQueryViewModel>;
