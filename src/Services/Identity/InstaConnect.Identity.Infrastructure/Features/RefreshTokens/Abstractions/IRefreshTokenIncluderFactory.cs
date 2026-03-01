using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

internal interface IRefreshTokenIncluderFactory
    : IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IRefreshTokenIncluder, RefreshToken>;
