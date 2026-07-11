using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserMatcher
{
	public static UserInclude IsUserInclude(UpdateUserCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(include));
	}

	public static User IsUser(AddUserCommand command)
	{
		return Matcher.Is<User>(p => p.Matches(command));
	}

	public static User IsUser(UpdateUserCommand command)
	{
		return Matcher.Is<User>(p => p.Matches(command));
	}

	public static User IsUser(DeleteUserCommand command)
	{
		return Matcher.Is<User>(p => p.Matches(command));
	}

	public static UserAddedEventRequest IsUserAddedEventRequest(AddUserCommand command, User user)
	{
		return Matcher.Is<UserAddedEventRequest>(p => p.Matches(command, user));
	}

	public static UserUpdatedEventRequest IsUserUpdatedEventRequest(UpdateUserCommand command, User user)
	{
		return Matcher.Is<UserUpdatedEventRequest>(p => p.Matches(command, user));
	}

	public static UserDeletedEventRequest IsUserDeletedEventRequest(DeleteUserCommand command, User user)
	{
		return Matcher.Is<UserDeletedEventRequest>(p => p.Matches(command, user));
	}

	public static EmailConfirmationToken IsEmailConfirmationToken(AddUserCommand command, User user)
	{
		return Matcher.Is<EmailConfirmationToken>(p => p.Matches(command, user));
	}

	public static EmailConfirmationTokenAddedEventRequest IsEmailConfirmationTokenAddedEventRequest(AddUserCommand command, EmailConfirmationToken emailConfirmationToken)
	{
		return Matcher.Is<EmailConfirmationTokenAddedEventRequest>(p => p.Matches(command, emailConfirmationToken));
	}

	public static ICollection<EmailConfirmationTokenDeletedEventRequest> IsEmailConfirmationTokenDeletedEventRequestCollection(UpdateUserCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		return Matcher.Is<ICollection<EmailConfirmationTokenDeletedEventRequest>>(p => p.Matches(command, emailConfirmationTokens));
	}
}
