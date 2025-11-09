using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    public static async Task ShouldReceiveOneAddAsync(
        this IUserService userService,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceived(1).AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IUserService userService,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceived(1).UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IUserService userService,
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceived(1).DeleteAsync(UserMatcher.IsDeleteUserCommand(request), cancellationToken);
    }
}
