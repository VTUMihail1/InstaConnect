namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenFactory
{
	public ForgotPasswordToken Create(UserId id);
}
