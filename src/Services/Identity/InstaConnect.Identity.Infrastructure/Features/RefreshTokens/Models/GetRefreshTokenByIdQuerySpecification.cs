namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;

public record GetRefreshTokenByIdQuerySpecification(
    string Sql,
    GetRefreshTokenByIdQueryParameters Parameters);
