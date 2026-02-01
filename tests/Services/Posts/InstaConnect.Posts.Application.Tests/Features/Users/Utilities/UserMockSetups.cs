namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserMockSetups
{
    public static void SetupAddCommand(
        this IUserCommandService userService,
        AddUserCommandRequest request,
        User user,
        CancellationToken cancellationToken)
    {
        userService
            .AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken)
            .ReturnsResponse(user.ToResponse(request));
    }

    public static void SetupUpdateCommand(
        this IUserCommandService userService,
        UpdateUserCommandRequest request,
        User user,
        CancellationToken cancellationToken)
    {
        userService
            .UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken)
            .ReturnsResponse(user.ToResponse(request));
    }
}
