using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(AddUserCommandResponse response)
	{
		public void ShouldSatisfy(User user, AddUserCommandRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(UpdateCurrentUserCommandResponse response)
	{
		public void ShouldSatisfy(User user, UpdateCurrentUserCommandRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(GetUserByIdQueryResponse response)
	{
		public void ShouldSatisfy(User user, GetUserByIdQueryRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(GetCurrentUserByIdQueryResponse response)
	{
		public void ShouldSatisfy(User user, GetCurrentUserByIdQueryRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(GetUserDetailsByIdQueryResponse response)
	{
		public void ShouldSatisfy(User user, GetUserDetailsByIdQueryRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(GetCurrentUserDetailsByIdQueryResponse response)
	{
		public void ShouldSatisfy(User user, GetCurrentUserDetailsByIdQueryRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(user, request));
		}
	}

	extension(GetAllUsersQueryResponse response)
	{
		public void ShouldSatisfy(
		ICollection<User> users,
		GetAllUsersQueryRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(users, request));
		}

		public void ShouldSatisfy(
			ICollection<User> users,
			GetAllUsersQueryRequest request,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(users, request, termTransformer));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommandRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}

		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommandRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}
}
