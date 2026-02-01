using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    public static async Task ShouldReceiveOneAddAsync(
        this IUserCommandService userService,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceivedOne().AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IUserCommandService userService,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceivedOne().UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IUserCommandService userService,
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.ShouldHaveReceivedOne().DeleteAsync(UserMatcher.IsDeleteUserCommand(request), cancellationToken);
    }
}
