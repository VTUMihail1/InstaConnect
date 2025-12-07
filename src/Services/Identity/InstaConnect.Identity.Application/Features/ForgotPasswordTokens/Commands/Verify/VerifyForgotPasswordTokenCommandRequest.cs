namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

public record VerifyForgotPasswordTokenCommandRequest(
    string Id,
    string Value,
    string Password,
    string ConfirmPassword) : ICommandRequest;
