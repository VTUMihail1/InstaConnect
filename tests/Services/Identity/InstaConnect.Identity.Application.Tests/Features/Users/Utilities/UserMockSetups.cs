namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllUsersQueryRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(UserApplicationMatcher.IsGetAllUsersQuery(request), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserApplicationMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserApplicationMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserApplicationMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserApplicationMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}

	extension(IUserCommandService service)
	{
		public void SetupAddAsync(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(UserApplicationMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(UserApplicationMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
