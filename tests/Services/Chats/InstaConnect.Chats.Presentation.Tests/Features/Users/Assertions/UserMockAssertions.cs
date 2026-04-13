using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsAddUserCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            UserUpdatedEventRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsUpdateUserCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            UserDeletedEventRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsDeleteUserCommandRequest(request), cancellationToken);
        }
    }
}
