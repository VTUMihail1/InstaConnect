using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserEventAssertions
{
	extension(UserAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserCommandRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdateCurrentUserCommandRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserCommandRequest request, User entity)
		{
			return r.Matches(request, entity);
		}

		public bool ShouldSatisfy(DeleteCurrentUserCommandRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}


	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(UpdateCurrentUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
