using InstaConnect.Common.Application.Features.Requests.Abstractions;

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
				.SendAsync(request.IsGetAllUsersQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupSendAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetUserByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetUserDetailsByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetCurrentUserByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetCurrentUserDetailsByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsAddUserCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsUpdateCurrentUserCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
