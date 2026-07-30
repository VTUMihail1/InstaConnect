namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMatcher
{
	public static AddForgotPasswordTokenCommand IsAddForgotPasswordTokenCommand(AddForgotPasswordTokenCommandRequest request)
	{
		return Matcher.Is<AddForgotPasswordTokenCommand>(p => p.Matches(request));
	}

	public static VerifyForgotPasswordTokenCommand IsVerifyForgotPasswordTokenCommand(VerifyForgotPasswordTokenCommandRequest request)
	{
		return Matcher.Is<VerifyForgotPasswordTokenCommand>(p => p.Matches(request));
	}
}
