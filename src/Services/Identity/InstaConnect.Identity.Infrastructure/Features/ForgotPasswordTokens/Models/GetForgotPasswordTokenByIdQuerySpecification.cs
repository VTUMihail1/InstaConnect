namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;

public record GetForgotPasswordTokenByIdQuerySpecification(
    string Sql,
    GetForgotPasswordTokenByIdQueryParameters Parameters);
