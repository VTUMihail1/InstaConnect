using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

internal interface IUserClaimIncluderFactory
    : IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IUserClaimIncluder, UserClaim>;
