using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(string Id) : IQuery<UserQueryViewModel>;
