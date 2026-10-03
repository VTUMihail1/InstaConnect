using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimIncluder : IIncluder<UserClaim, IdentityIncludeType, IdentityDestinationType>;
