using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, IdentityIncludeType, IdentityDestinationType>;
