using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this User user, UserAddedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Matches(request));
    }

    public static void ShouldSatisfy(this User u, User user)
    {
        user.ShouldSatisfy(u => u.Matches(user));
    }

    public static void ShouldSatisfy(this User user, UserUpdatedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Matches(request));
    }
}
