using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(UserMatcher.IsAddUserCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(UserMatcher.IsUpdateUserCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(UserMatcher.IsDeleteUserCommandRequest(request), cancellationToken);
    }
}
