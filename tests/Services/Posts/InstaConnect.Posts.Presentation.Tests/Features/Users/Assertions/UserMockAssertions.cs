using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsAddUserCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsUpdateUserCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsDeleteUserCommandRequest(request), cancellationToken);
    }
}
