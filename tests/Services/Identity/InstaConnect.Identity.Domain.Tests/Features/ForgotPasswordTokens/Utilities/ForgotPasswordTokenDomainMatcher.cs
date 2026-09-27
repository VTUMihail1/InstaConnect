using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDomainMatcher
{
	public static UserInclude IsUserInclude(VerifyForgotPasswordTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static User IsUser(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
	{
		return Matcher.Is<User>(p => p.Matches(command, passwordHasher));
	}

	public static ForgotPasswordToken IsForgotPasswordToken(AddForgotPasswordTokenCommand command)
	{
		return Matcher.Is<ForgotPasswordToken>(p => p.Matches(command));
	}

	public static ICollection<ForgotPasswordToken> IsForgotPasswordTokenCollection(VerifyForgotPasswordTokenCommand command)
	{
		return Matcher.Is<ICollection<ForgotPasswordToken>>(p => p.Matches(command));
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
