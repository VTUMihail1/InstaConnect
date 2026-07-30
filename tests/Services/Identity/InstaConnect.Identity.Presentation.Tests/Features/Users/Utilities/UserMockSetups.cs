using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllUsersApiRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsGetAllUsersQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupGetByIdQueryRequest(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsGetUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetDetailsByIdQueryRequest(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsGetUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentByIdQueryRequest(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsGetCurrentUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentDetailsByIdQueryRequest(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsGetCurrentUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsAddUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateCurrentCommandRequest(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserPresentationMatcher.IsUpdateCurrentUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
