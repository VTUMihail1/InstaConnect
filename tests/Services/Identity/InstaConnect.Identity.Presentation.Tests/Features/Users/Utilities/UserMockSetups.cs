using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllUsersApiRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsGetAllUsersQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupSendAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsGetUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsGetUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsGetCurrentUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsGetCurrentUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsAddUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserPresentationMatcher.IsUpdateCurrentUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
