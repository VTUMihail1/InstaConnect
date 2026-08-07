using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsGetAllUsersQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsGetUserByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsGetCurrentUserByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsGetUserDetailsByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsGetCurrentUserDetailsByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsAddUserCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsUpdateCurrentUserCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsDeleteUserCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(UserPresentationMatcher.IsDeleteCurrentUserCommandRequest(request), cancellationToken);
		}
	}
}
