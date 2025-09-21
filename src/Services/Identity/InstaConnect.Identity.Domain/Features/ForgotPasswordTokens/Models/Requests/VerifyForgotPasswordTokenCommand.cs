namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record VerifyForgotPasswordTokenCommand(string Id, string Value, string Password, string ConfirmPassword);
