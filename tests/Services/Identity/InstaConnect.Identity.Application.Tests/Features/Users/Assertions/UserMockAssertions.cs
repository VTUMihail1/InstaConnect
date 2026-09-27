using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserQueryService userService)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllUsersQueryRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllUsersQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}
	}

	extension(IUserCommandService userService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().AddAsync(request.IsAddUserCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().UpdateAsync(request.IsUpdateUserCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}
	}
}
