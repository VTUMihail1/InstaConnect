namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserMockSetups
{
    public static void SetupAddCommand(
        this IUserService UserService,
        AddUserCommandRequest request,
        User User,
        CancellationToken cancellationToken)
    {
        UserService
            .AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken)
            .ReturnsResponse(User);
    }

    public static void SetupUpdateCommand(
        this IUserService UserService,
        UpdateUserCommandRequest request,
        User User,
        CancellationToken cancellationToken)
    {
        UserService
            .UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken)
            .ReturnsResponse(User);
    }
}
