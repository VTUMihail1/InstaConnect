namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenEmailSender
{
    Task SendAsync(ForgotPasswordToken forgotPasswordToken, CancellationToken cancellationToken);
}
