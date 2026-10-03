namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

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
				.AddAsync(request.IsAddUserCommand(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService
				.UpdateAsync(request.IsUpdateUserCommand(), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}
}
