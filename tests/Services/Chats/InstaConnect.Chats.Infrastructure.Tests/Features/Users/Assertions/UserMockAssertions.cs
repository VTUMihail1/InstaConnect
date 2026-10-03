using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		UserAddedEventRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsUpdateUserCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteUserCommandRequest(), cancellationToken);
		}
	}
}
