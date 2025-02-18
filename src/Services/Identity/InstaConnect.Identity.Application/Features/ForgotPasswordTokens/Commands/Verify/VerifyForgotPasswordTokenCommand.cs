namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

public record VerifyForgotPasswordTokenCommand(string UserId, string Token, string Password, string ConfirmPassword) : ICommand;
