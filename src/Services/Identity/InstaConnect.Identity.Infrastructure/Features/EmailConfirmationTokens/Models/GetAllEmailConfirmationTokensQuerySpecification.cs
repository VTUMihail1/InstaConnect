namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

public record GetAllEmailConfirmationTokensQuerySpecification(
    string Sql,
    GetAllEmailConfirmationTokensQueryParameters Parameters);
