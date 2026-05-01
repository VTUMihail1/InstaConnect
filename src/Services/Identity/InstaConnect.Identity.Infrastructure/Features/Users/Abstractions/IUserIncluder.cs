using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, IdentityIncludeType, IdentityDestinationType>;
