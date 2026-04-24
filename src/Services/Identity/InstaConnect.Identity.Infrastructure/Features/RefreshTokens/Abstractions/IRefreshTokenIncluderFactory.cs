using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

internal interface IRefreshTokenIncluderFactory
    : IIncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IRefreshTokenIncluder, RefreshToken>;
