using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenDomainMatcher
{
	public static UserInclude IsUserInclude(VerifyEmailConfirmationTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static EmailConfirmationToken IsEmailConfirmationToken(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
	{
		return Matcher.Is<EmailConfirmationToken>(p => p.Matches(emailConfirmationToken));
	}

	public static EmailConfirmationTokenAddedEventRequest IsEmailConfirmationTokenAddedEventRequest(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
	{
		return Matcher.Is<EmailConfirmationTokenAddedEventRequest>(p => p.Matches(command, emailConfirmationToken));
	}

	public static ICollection<EmailConfirmationTokenDeletedEventRequest> IsEmailConfirmationTokenDeletedEventRequestCollection(VerifyEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		return Matcher.Is<ICollection<EmailConfirmationTokenDeletedEventRequest>>(p => p.Matches(command, emailConfirmationTokens));
	}
}
