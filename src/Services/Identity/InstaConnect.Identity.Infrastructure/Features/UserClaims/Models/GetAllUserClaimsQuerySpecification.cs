namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

public record GetAllUserClaimsQuerySpecification(
    string Sql,
    GetAllUserClaimsQueryParameters Parameters);
