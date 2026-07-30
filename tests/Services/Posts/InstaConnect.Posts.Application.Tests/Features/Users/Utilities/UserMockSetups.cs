namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserCommandService userService)
	{
		public void SetupAddCommand(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			userService
				.AddAsync(UserApplicationMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService
				.UpdateAsync(UserApplicationMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
