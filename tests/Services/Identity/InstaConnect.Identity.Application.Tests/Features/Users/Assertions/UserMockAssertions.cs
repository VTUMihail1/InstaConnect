using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserQueryService userService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllUsersQueryRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllUsersQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}
	}

	extension(IUserCommandService userService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().AddAsync(request.IsAddUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().UpdateAsync(request.IsUpdateUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}
	}
}
