namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserCommandService userService)
	{
		public void SetupAddAsync(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			userService
				.ClearCalls()
				.AddAsync(UserApplicationMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService
				.ClearCalls()
				.UpdateAsync(UserApplicationMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
