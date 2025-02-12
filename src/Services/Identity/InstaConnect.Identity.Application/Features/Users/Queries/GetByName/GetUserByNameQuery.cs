using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetByName;

public record GetUserByNameQuery(string UserName) : IQuery<UserQueryViewModel>;
