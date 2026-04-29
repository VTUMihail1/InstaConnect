namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserQueryService service)
	{
		public void SetupGetAllQuery(
		GetAllUsersQueryRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(UserMatcher.IsGetAllUsersQuery(request), cancellationToken)
				.ReturnsResponse(users.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}
	}

	extension(IUserCommandService service)
	{
		public void SetupAddCommand(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}
	}
}
