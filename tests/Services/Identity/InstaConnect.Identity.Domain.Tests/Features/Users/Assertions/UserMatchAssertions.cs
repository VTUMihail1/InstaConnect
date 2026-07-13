using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(UserId response)
	{
		public void ShouldSatisfy(User user, AddUserCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(user, command));
		}

		public void ShouldSatisfy(User user, UpdateUserCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(user, command));
		}
	}

	extension(UserResponse response)
	{
		public void ShouldSatisfy(User user, GetUserByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, query));
		}
	}

	extension(UserCollectionResponse response)
	{
		public void ShouldSatisfy(
			ICollection<User> users,
			GetAllUsersQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(users, query));
		}

		public void ShouldSatisfy(
			ICollection<User> users,
			GetAllUsersQuery query,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(users, query, termTransformer));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdateUserCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(command, passwordHasher));
		}
	}
}
