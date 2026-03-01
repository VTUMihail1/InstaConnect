using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

internal interface IRefreshTokenIncluder : IIncluder<RefreshToken, IdentityIncludeType, IdentityDestinationType>;
