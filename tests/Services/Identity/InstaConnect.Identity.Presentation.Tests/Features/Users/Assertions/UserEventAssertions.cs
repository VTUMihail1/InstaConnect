using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserEventAssertions
{
	extension(UserAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddUserApiRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdateCurrentUserApiRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteUserApiRequest request, User entity)
		{
			return r.Matches(request, entity);
		}

		public bool ShouldSatisfy(DeleteCurrentUserApiRequest request, User entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}


	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(UpdateCurrentUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
