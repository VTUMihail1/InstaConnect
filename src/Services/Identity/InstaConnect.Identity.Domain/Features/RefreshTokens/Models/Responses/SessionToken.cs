using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;
public record SessionToken(
    RefreshToken RefreshToken,
    AccessToken AccessToken);
