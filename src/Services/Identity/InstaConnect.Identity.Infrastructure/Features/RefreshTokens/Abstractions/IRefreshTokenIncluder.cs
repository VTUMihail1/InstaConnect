using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

internal interface IRefreshTokenIncluder : IIncluder<RefreshToken, IdentityIncludeType, IdentityDestinationType>;
