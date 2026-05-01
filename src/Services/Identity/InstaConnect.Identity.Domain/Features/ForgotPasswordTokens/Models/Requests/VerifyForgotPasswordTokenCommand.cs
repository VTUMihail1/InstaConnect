namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record VerifyForgotPasswordTokenCommand(ForgotPasswordTokenId Id, string Password, string ConfirmPassword);
