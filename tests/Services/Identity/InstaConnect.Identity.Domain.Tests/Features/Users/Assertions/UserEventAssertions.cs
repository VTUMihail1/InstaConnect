using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserEventAssertions
{
	extension(UserAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserCommand command, User entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdateUserCommand command, User entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserCommand command, User entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(command, entities);
		}
	}


	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(UpdateUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(command, entities);
		}
	}
}
