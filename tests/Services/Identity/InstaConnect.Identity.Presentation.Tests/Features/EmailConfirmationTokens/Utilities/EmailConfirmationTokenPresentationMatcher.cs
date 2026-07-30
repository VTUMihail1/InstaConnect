namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMatcher
{
	public static AddEmailConfirmationTokenCommandRequest IsAddEmailConfirmationTokenCommandRequest(AddEmailConfirmationTokenApiRequest request)
	{
		return Matcher.Is<AddEmailConfirmationTokenCommandRequest>(p => p.Matches(request));
	}

	public static VerifyEmailConfirmationTokenCommandRequest IsVerifyEmailConfirmationTokenCommandRequest(VerifyEmailConfirmationTokenApiRequest request)
	{
		return Matcher.Is<VerifyEmailConfirmationTokenCommandRequest>(p => p.Matches(request));
	}
}
