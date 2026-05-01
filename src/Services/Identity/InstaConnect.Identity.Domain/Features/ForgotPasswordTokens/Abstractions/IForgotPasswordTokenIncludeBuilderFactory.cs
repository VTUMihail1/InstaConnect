using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeBuilderFactory
{
	public ForgotPasswordTokenIncludeBuilder Create();
}
