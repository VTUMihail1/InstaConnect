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
				.GetAllAsync(request.IsGetAllUsersQuery(), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddUserCommand(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(request.IsUpdateUserCommand(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
