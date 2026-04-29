namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenEmailSender
{
	public Task SendAsync(ForgotPasswordToken forgotPasswordToken, CancellationToken cancellationToken);
}
