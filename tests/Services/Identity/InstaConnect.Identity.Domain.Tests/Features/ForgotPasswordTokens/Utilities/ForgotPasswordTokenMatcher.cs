using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMatcher
{
	public static UserInclude IsUserInclude(VerifyForgotPasswordTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static ForgotPasswordToken IsForgotPasswordToken(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
	{
		return Matcher.Is<ForgotPasswordToken>(p => p.Matches(forgotPasswordToken));
	}

	public static ForgotPasswordTokenAddedEventRequest IsForgotPasswordTokenAddedEventRequest(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
	{
		return Matcher.Is<ForgotPasswordTokenAddedEventRequest>(p => p.Matches(command, forgotPasswordToken));
	}

	public static ICollection<ForgotPasswordTokenDeletedEventRequest> IsForgotPasswordTokenDeletedEventRequestCollection(VerifyForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		return Matcher.Is<ICollection<ForgotPasswordTokenDeletedEventRequest>>(p => p.Matches(command, forgotPasswordTokens));
	}
}
