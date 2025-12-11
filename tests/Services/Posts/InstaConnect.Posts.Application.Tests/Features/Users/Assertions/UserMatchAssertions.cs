using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this AddUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Matches(user));
    }

    public static void ShouldSatisfy(this UpdateUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Matches(user));
    }

    public static void ShouldSatisfy(this User user, AddUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Matches(request));
    }

    public static void ShouldSatisfy(this User user, UpdateUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Matches(request));
    }
}
