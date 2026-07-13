using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMatcher
{
	public static UserInclude IsUserInclude(VerifyEmailConfirmationTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(include));
	}

	public static EmailConfirmationToken IsEmailConfirmationToken(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
	{
		return Matcher.Is<EmailConfirmationToken>(p => p.Matches(emailConfirmationToken));
	}

	public static EmailConfirmationTokenAddedEventRequest IsEmailConfirmationTokenAddedEventRequest(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
	{
		return Matcher.Is<EmailConfirmationTokenAddedEventRequest>(p => p.Matches(command, emailConfirmationToken));
	}

	public static ICollection<EmailConfirmationTokenDeletedEventRequest> IsEmailConfirmationTokenDeletedEventRequestCollection(VerifyEmailConfirmationTokenCommand command, User user)
	{
		return Matcher.Is<ICollection<EmailConfirmationTokenDeletedEventRequest>>(p => p.Matches(user));
	}
}
