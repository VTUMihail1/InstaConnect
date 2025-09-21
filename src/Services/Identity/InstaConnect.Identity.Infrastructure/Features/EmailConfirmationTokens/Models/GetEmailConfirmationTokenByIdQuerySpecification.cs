namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;

public record GetEmailConfirmationTokenByIdQuerySpecification(
    string Sql,
    GetEmailConfirmationTokenByIdQueryParameters Parameters);
