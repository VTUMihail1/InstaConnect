using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserCommandService userService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().AddAsync(UserApplicationMatcher.IsAddUserCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().UpdateAsync(UserApplicationMatcher.IsUpdateUserCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(UserApplicationMatcher.IsDeleteUserCommand(request), cancellationToken);
		}
	}
}
