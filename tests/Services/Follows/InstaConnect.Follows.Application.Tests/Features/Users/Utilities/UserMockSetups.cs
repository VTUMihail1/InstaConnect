namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

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
				.AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService
				.UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsResponse(user.ToResponse(request));
		}
	}
}
