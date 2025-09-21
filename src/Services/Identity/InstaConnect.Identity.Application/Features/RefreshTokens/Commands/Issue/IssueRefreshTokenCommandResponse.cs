using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;

public record IssueRefreshTokenCommandResponse(
    RefreshTokenCommandResponse RefreshToken,
    AccessTokenCommandResponse AccessToken);
