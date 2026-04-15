namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;

public record VerifyForgotPasswordTokenApiBody(
        string Password,
        string ConfirmPassword);
