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
				.SendAsync(UserMatcher.IsGetAllUsersQueryRequest(request), cancellationToken)
				.ReturnsResponse(users.ToResponse(request));
		}

		public void SetupGetByIdQueryRequest(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetUserByIdQueryRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetDetailsByIdQueryRequest(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentByIdQueryRequest(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetCurrentUserByIdQueryRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentDetailsByIdQueryRequest(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetCurrentUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsAddUserCommandRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupUpdateCurrentCommandRequest(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsUpdateCurrentUserCommandRequest(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}
	}
}
