using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserIncluder : IIncluder<User, IdentityIncludeType, IdentityDestinationType>;
